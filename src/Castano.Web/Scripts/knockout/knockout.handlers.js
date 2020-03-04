ko.bindingHandlers.dateString = {
    update: function (element, valueAccessor, allBindingsAccessor) {
        var value = ko.utils.unwrapObservable(valueAccessor());
        var allBindings = allBindingsAccessor();

        var format = allBindings.format || 'DD/MM/YYYY'; // default format.

        if (value && value != 'Invalid Date') {
            var formattedDate = moment(value).format(format);
            if ($(element).is('input')) {
                $(element).val(formattedDate);
            } else {
                $(element).text(formattedDate);
            }
        } else {
            if ($(element).is('input')) {
                $(element).val('');
            } else {
                $(element).text('');
            }
        }
    }
}