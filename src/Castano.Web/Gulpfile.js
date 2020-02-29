var { series, parallel, src, dest } = require('gulp');
var concat = require('gulp-concat');

//css
function bootstrapcss() {
    return src('./vendor/bootstrap/css/bootstrap.css')
        .pipe(concat('bootstrap.css'))
        .pipe(dest('css/bootstrap/'));
}
function fontawosome() {
    return src('./vendor/fontawesome-free/css/all.min.css')
        .pipe(concat('fontawesome.css'))
        .pipe(dest('css/fontawesome/'));
}
function fontawsomefonts() {
    return src('./vendor/fontawesome-free/webfonts/*')
        .pipe(dest('css/webfonts/'));
}
function magnificcss() {
    return src('./vendor/magnific-popup/magnific-popup.css')
        .pipe(concat('magnific.css'))
        .pipe(dest('css/magnific-popup/'));
}

//js
function jquery() {
    return src('./vendor/jquery/jquery.min.js')
        .pipe(concat('jquery.js'))
        .pipe(dest('js/jquery/'));
}
function bootstrapjs() {
    return src('./vendor/bootstrap/js/bootstrap.bundle.min.js')
        .pipe(concat('bootstrap.js'))
        .pipe(dest('js/bootstrap/'));
}
function jqueryeasing() {
    return src('./vendor/jquery-easing/jquery.easing.min.js')
        .pipe(concat('jquery.easing.js'))
        .pipe(dest('js/jquery.easing/'));
}
function scrollreveal() {
    return src('./vendor/scrollreveal/scrollreveal.min.js')
        .pipe(concat('scrollreveal.js'))
        .pipe(dest('js/scrollreveal/'));
}
function magnificjs() {
    return src('./vendor/magnific-popup/jquery.magnific-popup.min.js')
        .pipe(concat('magnific.popup.js'))
        .pipe(dest('js/magnific-popup/'));
}

//datatables
function datatables() {
    return src('./node_modules/datatables.net/js/jquery.datatables.js')
        .pipe(concat('datatables.js'))
        .pipe(dest('js/datatables/'));
}
function datatablesBs4Css() {
    return src('./node_modules/datatables.net-bs4/css/datatables.bootstrap4.min.css')
        .pipe(concat('datatablesBs4.css'))
        .pipe(dest('css/datatables/'));
}
function datatablesBs4Js() {
    return src('./node_modules/datatables.net-bs4/js/datatables.bootstrap4.min.js')
        .pipe(concat('datatablesBs4.js'))
        .pipe(dest('js/datatables/'));
}
function datatablesButtons() {
    return src(['./node_modules/datatables.net-buttons/js/dataTables.buttons.min.js',
        './node_modules/datatables.net-buttons/js/buttons.print.min.js',
        './node_modules/datatables.net-buttons/js/buttons.html5.min.js'])
        .pipe(concat('datatablesButtons.js'))
        .pipe(dest('js/datatables/'));
}
function datatablesCopySwf() {
    return src('./node_modules/datatables.net-buttons/swf/flashExport.swf')
        .pipe(dest('swf/'));
}
function datatablesButtonsBs4Css() {
    return src('./node_modules/datatables.net-buttons-bs4/css/buttons.bootstrap4.min.css')
        .pipe(concat('datatablesButtonsBs4.css'))
        .pipe(dest('css/datatables/'));
}
function datatablesButtonsBs4Js() {
    return src('./node_modules/datatables.net-buttons-bs4/js/buttons.bootstrap4.min.js')
        .pipe(concat('datatablesButtonsBs4.js'))
        .pipe(dest('js/datatables/'));
}
function datatablesResponsiveJs() {
    return src('./node_modules/datatables.net-responsive/js/dataTables.responsive.min.js')
        .pipe(concat('datatablesResponsive.js'))
        .pipe(dest('js/datatables/'));
}
function datatablesResponsiveBs4Css() {
    return src('./node_modules/datatables.net-responsive-bs4/css/responsive.bootstrap4.min.css')
        .pipe(concat('datatablesResponsiveBs4.css'))
        .pipe(dest('css/datatables/'));
}
function datatablesResponsiveBs4Js() {
    return src('./node_modules/datatables.net-responsive-bs4/js/responsive.bootstrap4.min.js')
        .pipe(concat('datatablesResponsiveBs4.js'))
        .pipe(dest('js/datatables/'));
}
function jszip() {
    return src('./node_modules/jszip/dist/jszip.min.js')
        .pipe(concat('jszip.js'))
        .pipe(dest('js/datatables/'));
}


exports.default = series(
    parallel(bootstrapcss, fontawosome, magnificcss),
    fontawsomefonts,
    jquery,
    parallel(bootstrapjs, jqueryeasing, scrollreveal, magnificjs),
    parallel(datatables, datatablesBs4Css, datatablesBs4Js),
    parallel(datatablesButtons, datatablesCopySwf, datatablesButtonsBs4Css, datatablesButtonsBs4Js),
    parallel(datatablesResponsiveJs, datatablesResponsiveBs4Css, datatablesResponsiveBs4Js),
    jszip
);