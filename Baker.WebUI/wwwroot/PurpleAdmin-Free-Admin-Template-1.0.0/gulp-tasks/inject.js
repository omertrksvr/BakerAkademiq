'use strict'
var gulp = require('gulp');
var injectPartials = require('gulp-inject-partials');
var inject = require('gulp-inject');
var prettify = require('gulp-prettify');
var replace = require('gulp-replace');
var merge = require('merge-stream');

/* inject partials like sidebar and navbar */
gulp.task('injectPartial', function () {
    return gulp.src(["./pages/**/*.html", "./index.html"], {
        base: "./"
    })
        .pipe(injectPartials())
        .pipe(gulp.dest("."));
});

/* inject Js and CCS assets into HTML */
gulp.task('injectAssets', function () {
    return gulp.src(["./**/*.html"])
        .pipe(inject(gulp.src([
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/vendors/mdi/css/materialdesignicons.min.css',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/vendors/ti-icons/css/themify-icons.css',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/vendors/css/vendor.bundle.base.css',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/vendors/js/vendor.bundle.base.js',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/vendors/font-awesome/css/font-awesome.min.css'
        ], {
            read: false
        }), {
            name: 'plugins',
            relative: true
        }))
        .pipe(inject(gulp.src([
            // './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/css/shared/style.css',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/js/off-canvas.js',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/js/misc.js',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/js/settings.js',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/js/todolist.js',
            './~/PurpleAdmin-Free-Admin-Template-1.0.0/assets/js/jquery.cookie.js'
        ], {
            read: false
        }), {
            relative: true
        }))
        .pipe(gulp.dest('.'));
});

/*replace image path and linking after injection*/
gulp.task('replacePath', function () {
    var replacePath1 = gulp.src('./pages/**/*.html', {
        base: "./"
    })
        .pipe(replace('="../assets/', '="../../assets/'))
        .pipe(replace('href="../pages/', 'href="../../pages/'))
        .pipe(replace('="../docs/', '="../../docs/'))
        .pipe(replace('href="../index.html"', 'href="../../index.html"'))
        .pipe(gulp.dest('.'));
    var replacePath2 = gulp.src('./index.html', { base: "./" })
        .pipe(replace('="../assets/', '="assets/'))
        .pipe(replace('="../docs/', '="docs/'))
        .pipe(replace('="../pages/', '="pages/'))
        .pipe(replace('="../index.html"', '="index.html"'))
        .pipe(gulp.dest('.'));
    return merge(replacePath1, replacePath2);
});

gulp.task('html-beautify', function () {
    return gulp.src(['./**/*.html', '!node_modules/**/*.html'])
        .pipe(prettify({
            unformatted: ['pre', 'code', 'textarea']
        }))
        .pipe(gulp.dest(function (file) {
            return file.base;
        }));
});

/*sequence for injecting partials and replacing paths*/
gulp.task('inject', gulp.series('injectPartial', 'injectAssets', 'html-beautify', 'replacePath'));
