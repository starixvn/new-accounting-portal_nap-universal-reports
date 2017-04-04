// grab our gulp packages
let gulp = require('gulp'),
    gutil = require('gulp-util'),
    fs = require('fs'),
    cheerio = require('cheerio'),
    ejs = require('ejs');

let encoding = 'utf8';

function transform() {
    let outputFolder = getOutputFolder();
    changeFileNames(outputFolder);
    let options = readOptions(outputFolder);
    let template = fs.readFileSync('./src/index.ejs', encoding);
    let output = ejs.render(template, options);
    fs.writeFileSync(outputFolder + '/index.cshtml', output, encoding);
}

function getOutputFolder() {
    let content = fs.readFileSync('./.angular-cli.json', encoding);
    let json = JSON.parse(content);
    return json.apps[0].outDir;
}

function changeFileNames(outputFolder) {
    let fileNames = fs.readdirSync(outputFolder);
    let files = {
        css: [],
        js: []
    };

    fileNames.forEach(fileName => {
        let isCss = fileName.endsWith('.css');
        let isJs = fileName.endsWith('.js');
        if (isCss || isJs) {
            let words = fileName.split('.');
            let bundle = words[1];
            let newFileName = fileName.replace('.' + bundle, '');
            let oldPath = outputFolder + '/' + fileName;
            let newPath = outputFolder + '/' + newFileName;
            fs.renameSync(oldPath, newPath);
        }
    });

    return files;
}

function readOptions(outputFolder) {
    let resourceDir = outputFolder.replace(/\.\.\//g, '');
    let content = fs.readFileSync(outputFolder + '/index.html', encoding);
    let $ = cheerio.load(content);
    let files = {
        js: [],
        css: []
    };

    let styleElements = $('link');
    styleElements.map((index, element) => {
        let css = resourceDir + '/' + changeBundle($(element).attr('href'));
        files.css.push(css);
    });

    let scriptElements = $('script');
    scriptElements.map((index, element) => {
        let js = resourceDir + '/' + changeBundle($(element).attr('src'));
        files.js.push(js);
    });

    let title = $('title').text();

    let options = {
        title: title,
        files: files
    };
    return options;
}

function changeBundle(fileName) {
    let words = fileName.split('.');
    let bundle = words[1];
    let newFileName = fileName.replace('.' + bundle, '');
    let newBundleName = newFileName + '?' + bundle;
    return newBundleName;
}

gulp.task('transform', () => {
    gutil.log('Transform started');
    transform();
    gutil.log('Transform completed');
});