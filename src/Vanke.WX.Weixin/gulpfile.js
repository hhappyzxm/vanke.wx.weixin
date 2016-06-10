var gulp = require("gulp"),
    rimraf = require("rimraf"),
    sass = require('gulp-sass');

var paths = {
    webroot: "./wwwroot/",
    bower: "./bower_components/",
    lib: "./wwwroot/lib/"
};

gulp.task("install", ["clean:lib"], function () {
    var bower = {
        "bootstrap": "bootstrap/dist/**/*.{js,map,css,ttf,svg,woff,woff2,eot}",
        "jquery": "jquery/dist/*.js",
        "angular": "angular/*.{js,css}",
        "angular-bootstrap": "angular-bootstrap/*.{js,css}",
        "angular-ui-router": "angular-ui-router/release/*.js",
        "angular-resource": "angular-resource/*.js",
        "requirejs": "requirejs/*.js",
        "metisMenu": "metisMenu/dist/*.{js,css}",
        "font-awesome": "font-awesome/**/*.{css,ttf,svg,woff,woff2,eot}",
        "animate.css": "animate.css/*.css",
        "jquery-sticky": "jquery-sticky/*.js",
        "flot": "flot/*.js",
        "angular-flot": "angular-flot/*.js",
        "datatables": "datatables/media/**/*.{js,css,png}",
        "datatables-buttons": "datatables-buttons/**/*.js",
        "datatables-responsive": "datatables-responsive/**/*.js",
        "angular-datatables": "angular-datatables/dist/**/*.js",
        "sweetalert2": "sweetalert2/dist/*.{js,css}",
        "ng-file-upload": "ng-file-upload/*.js"
    }

    for (var destinationDir in bower) {
        gulp.src(paths.bower + bower[destinationDir])
            .pipe(gulp.dest(paths.lib + destinationDir));
    }

    var sassTargets = {
        "datatables-responsive": "datatables-responsive/**/*.scss",
        "datatables-buttons": "datatables-buttons/**/*.scss"
    };

    for (var destinationDir in sassTargets) {
        gulp.src(paths.bower + sassTargets[destinationDir])
            .pipe(sass().on('error', sass.logError))
            .pipe(gulp.dest(paths.lib + destinationDir));
    }
});

gulp.task("clean:lib", function (cb) {
    rimraf(paths.lib, cb);
});