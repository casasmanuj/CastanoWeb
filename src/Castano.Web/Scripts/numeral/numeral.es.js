// load a locale
numeral.register('locale', 'es', {
    delimiters: {
        thousands: '.',
        decimal: ','
    },
    currency: {
        symbol: '$'
    }
});

// switch between locales
numeral.locale('es');