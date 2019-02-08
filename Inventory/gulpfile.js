/// <binding Clean='clean' />
"use strict";

var gulp = require("gulp"),
    rimraf = require("rimraf"),
    less = require("gulp-less"),
    sass = require("gulp-sass"); // добавляем модуль sass

var browserSync = require('browser-sync').create();

var paths = {
    webroot: "./wwwroot/"
};
// регистрируем задачу для конвертации файла scss в css
gulp.task("sass", function (done) {
    gulp.src('src/scss/style.scss')
        .pipe(sass())
        .pipe(gulp.dest(paths.webroot + '/css'))
        .pipe(browserSync.stream());

    done();
});

gulp.task('serve', function (done) {

    browserSync.init({
        https: true,
        proxy: "https://localhost:44361",
        //files: ["src/scss/*.scss", "Views/**/*.cshtml"]
    });

    gulp.watch("src/scss/*.scss", gulp.series('sass'));
    gulp.watch("Views/**/*.cshtml").on('change', () => {
        browserSync.reload();
        done();
    });


    done();
});

gulp.task('default', gulp.series('sass', 'serve'));