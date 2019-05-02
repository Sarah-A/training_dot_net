/// <binding AfterBuild='default' />
var gulp = require("gulp");
var uglify = require("gulp-uglify");
var concat = require("gulp-concat");

function minify() {
	return gulp.src("wwwroot/js/**/*.js")
		.pipe(uglify())
		.pipe(concat("dutchtreat.min.js"))
		.pipe(gulp.dest("wwwroot/dist"));
};


// This is the default gulp task that will run if not other task is specifically requested:
function defaultTask(cb) {
	minify();
	cb();
}

exports.default = defaultTask;



