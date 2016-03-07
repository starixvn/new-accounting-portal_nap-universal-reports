//S1:
module.exports = function (grunt) {
    'use strict';

    //S2    
    grunt.initConfig({
        //S3:Open the package.json
        pkg: grunt.file.readJSON('package.json'),
        //S4:The Concate Task
        concat: {
            companyWinLoss: {
                options: {
                    separator: '\n\r',
                    banner: '/* Author: Nexcel -  <%= grunt.template.today("yyyy-mm-dd") %> */\n'
                },
                // select the files to concatenate
                src: ['app/company-winloss/*.js', 'app/company-winloss/**/*.js'],
                // the resulting JS file
                dest: 'app/company-win-loss-concat.js'
            },
            app: {
                options: {
                    separator: '\n\r',
                    banner: '/* Author: Nexcel -  <%= grunt.template.today("yyyy-mm-dd") %> */\n'
                },
                // select the files to concatenate
                src: ['app/app.js', 'app/app.constant.js', 'app/app.config.js'],
                // the resulting JS file
                dest: 'app/app-concat.js'
            },
            common: {
                options: {
                    separator: '\n\r',
                    banner: '/* Author: Nexcel -  <%= grunt.template.today("yyyy-mm-dd") %> */\n'
                },
                // select the files to concatenate
                src: ['app/common/*.js', 'app/components/*.js', 'app/components/**/*.js', 'app/legacy-scripts/*.js'],
                // the resulting JS file
                dest: 'app/common-concat.js'
            }
        },

        //S5:Task for Minification
        uglify: {
            options: {
                //  banner for inserting at the top of the result
                banner: '/*! <%= pkg.name %> <%= grunt.template.today("dd-mm-yyyy") %> */\n'
            },
            companyWinLoss: {
                src: ['app/company-win-loss-concat.js'],
                dest: 'app/company-win-loss.min.js'
            },
            app: {
                src: ['app/app-concat.js'],
                dest: 'app/app.min.js'
            },
            common: {
                src: ['app/common-concat.js'],
                dest: 'app/common.min.js'
            }
        }
    });

    //S6: The Required Plug-Ins whihc will be loaded for Task
    grunt.loadNpmTasks('grunt-contrib-concat');

    grunt.loadNpmTasks('grunt-contrib-uglify');

    //S7: the array of tasks
    grunt.registerTask('default', ['concat', 'uglify']);
};