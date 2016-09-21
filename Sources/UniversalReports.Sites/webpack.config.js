/// <binding BeforeBuild='Run - Development' />
"use strict";
var webpack = require('webpack');
var path = require('path');
var extractTextPlugin = require("extract-text-webpack-plugin");
var cleanWebpackPlugin = require('clean-webpack-plugin');
var glob = require("glob-all");


module.exports = {
    verbose: false,
    debug: false,
    entry: {
        "app": glob.sync([
                  "./Scripts/Fanex.Grid.js",
                  "./Scripts/Fanex.Pagination.js",
                  "./app/root/app.js",
                  "./app/root/app.constant.js",
                  "./app/root/**/*.js"]),
        "app-style": glob.sync([
            "./content/site.scss",
            "./scripts/Fanex.Grid.css",
            "./scripts/Fanex.Pagination.css",
            "./app/root/**/*.scss",
            "./app/root/**/*.less",
            "./app/root/**/*.css"]),
        "house-win-loss": glob.sync(["./app/house-win-loss/*.js", "./app/house-win-loss/**/*.js"]),
        "house-win-loss-style": ["./content/house-win-loss.scss", "./content/scoreInformation.scss"],
        "ng2-statistic": glob.sync(["./app/ng2-statistic/*.js", "./app/ng2-statistic/**/*.js"]),
        "ng2-statistic-style": ["./content/ng2-statistic.scss"]
    },
    output: {
        path: path.join(__dirname, 'bundle'),
        filename: "[name].chunk.js",
        publicPath: '/bundle/',
    },
    devtool: 'source-map',
    devServer: {
        contentBase: ".",
        host: "localhost",
        port: 9009
    },
    plugins: initializePlugin(),
    module: {
        loaders: [
            {
                test: /\.js$/,
                loader: 'babel',
                exclude: /node_modules/,
                query: {
                    presets: ['es2015'],
                    compact: false
                }
            },
            {
                test: /\.tsx?$/,
                exclude: /(node_modules|bower_components)/,
                loader: 'ts-loader?configFileName=webpack.tsconfig.json'
            },
            {
                test: /\.scss$|\.css$/,
                loader: extractTextPlugin.extract("style-loader", "css-loader!sass-loader")
            },
             {
                 test: /\.less|\.css$$/,
                 loader: extractTextPlugin.extract("style-loader", "css-loader!less-loader")
             },
            {
                test: /\.jpe?g$|\.gif$|\.png$|\.svg$|\.woff$|\.woff2$|\.ttf$|\.eot$/,
                loader: "url?limit=100000"
            },
            {
                test: require.resolve("jquery"),
                loader: "expose?$!expose?jQuery"
            }
        ]
    }
};

function initializePlugin() {
    var plugins = [
    new extractTextPlugin('[name].css', { allChunks: true }),
    new cleanWebpackPlugin(['bundle'], {
        root: __dirname,
        verbose: true,
        dry: false,
        exclude: []
    }),
    new webpack.optimize.CommonsChunkPlugin({
        name: 'lib',
        minChunks: 2
    })
    ];

    var environemnt = process.env.NODE_ENV || 'development';
    if (environemnt !== 'development') {
        var unify = new webpack.optimize.UglifyJsPlugin({
            compress: {
                warnings: false
            }
        });
        plugins.push(unify);
    }


    return plugins;
}