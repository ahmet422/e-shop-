/// <binding />
var gulp = require('gulp');
var ugify = require("gulp-uglify");
var concat = require("gulp-concat");

function minify() {
    return gulp.src("wwwroot/js/**/*.js")
        .pipe(ugify())
        .pipe(concat("webapplication.min.js"))
        .pipe(gulp.dest("wwwroot/dist"));
};

exports.default = minify;