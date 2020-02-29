﻿/*=============================================================================
	Author:			Eric M. Barnard - @ericmbarnard								
	License:		MIT (http://opensource.org/licenses/mit-license.php)		
																				
	Description:	Validation Library for KnockoutJS							
	Version:		2.0.3											
===============================================================================
*/

!function (a) { "function" == typeof require && "object" == typeof exports && "object" == typeof module ? a(require("knockout"), exports) : "function" == typeof define && define.amd ? define(["knockout", "exports"], a) : a(ko, ko.validation = {}) }(function (a, b) { function c(a) { var b = "max" === a; return function (c, d) { if (f.utils.isEmptyVal(c)) return !0; var e, g; void 0 === d.typeAttr ? (g = "text", e = d) : (g = d.typeAttr, e = d.value), isNaN(e) || e instanceof Date || (g = "number"); var h, i, j; switch (g.toLowerCase()) { case "week": if (h = /^(\d{4})-W(\d{2})$/, i = c.match(h), null === i) throw new Error("Invalid value for " + a + " attribute for week input.  Should look like '2000-W33' http://www.w3.org/TR/html-markup/input.week.html#input.week.attrs.min"); return j = e.match(h), j ? b ? i[1] < j[1] || i[1] === j[1] && i[2] <= j[2] : i[1] > j[1] || i[1] === j[1] && i[2] >= j[2] : !1; case "month": if (h = /^(\d{4})-(\d{2})$/, i = c.match(h), null === i) throw new Error("Invalid value for " + a + " attribute for month input.  Should look like '2000-03' http://www.w3.org/TR/html-markup/input.month.html#input.month.attrs.min"); return j = e.match(h), j ? b ? i[1] < j[1] || i[1] === j[1] && i[2] <= j[2] : i[1] > j[1] || i[1] === j[1] && i[2] >= j[2] : !1; case "number": case "range": return b ? !isNaN(c) && parseFloat(c) <= parseFloat(e) : !isNaN(c) && parseFloat(c) >= parseFloat(e); default: return b ? e >= c : c >= e } } } function d(a, b, c) { return b.validator(a(), void 0 === c.params ? !0 : h(c.params)) ? !0 : (a.setError(f.formatMessage(c.message || b.message, h(c.params), a)), !1) } function e(a, b, c) { a.isValidating(!0); var d = function (d) { var e = !1, g = ""; return a.__valid__() ? (d.message ? (e = d.isValid, g = d.message) : e = d, e || (a.error(f.formatMessage(g || c.message || b.message, h(c.params), a)), a.__valid__(e)), void a.isValidating(!1)) : void a.isValidating(!1) }; f.utils.async(function () { b.validator(a(), void 0 === c.params ? !0 : h(c.params), d) }) } if ("undefined" == typeof a) throw new Error("Knockout is required, please ensure it is loaded before loading this validation plug-in"); a.validation = b; var f = a.validation, g = a.utils, h = g.unwrapObservable, i = g.arrayForEach, j = g.extend, k = { registerExtenders: !0, messagesOnModified: !0, errorsAsTitle: !0, errorsAsTitleOnModified: !1, messageTemplate: null, insertMessages: !0, parseInputAttributes: !1, writeInputAttributes: !1, decorateInputElement: !1, decorateElementOnModified: !0, errorClass: null, errorElementClass: "validationElement", errorMessageClass: "validationMessage", allowHtmlMessages: !1, grouping: { deep: !1, observable: !0, live: !1 }, validate: {} }, l = j({}, k); l.html5Attributes = ["required", "pattern", "min", "max", "step"], l.html5InputTypes = ["email", "number", "date"], l.reset = function () { j(l, k) }, f.configuration = l, f.utils = function () { var a = (new Date).getTime(), b = {}, c = "__ko_validation__"; return { isArray: function (a) { return a.isArray || "[object Array]" === Object.prototype.toString.call(a) }, isObject: function (a) { return null !== a && "object" == typeof a }, isNumber: function (a) { return !isNaN(a) }, isObservableArray: function (a) { return !!a && "function" == typeof a.remove && "function" == typeof a.removeAll && "function" == typeof a.destroy && "function" == typeof a.destroyAll && "function" == typeof a.indexOf && "function" == typeof a.replace }, values: function (a) { var b = []; for (var c in a) a.hasOwnProperty(c) && b.push(a[c]); return b }, getValue: function (a) { return "function" == typeof a ? a() : a }, hasAttribute: function (a, b) { return null !== a.getAttribute(b) }, getAttribute: function (a, b) { return a.getAttribute(b) }, setAttribute: function (a, b, c) { return a.setAttribute(b, c) }, isValidatable: function (a) { return !!(a && a.rules && a.isValid && a.isModified) }, insertAfter: function (a, b) { a.parentNode.insertBefore(b, a.nextSibling) }, newId: function () { return a += 1 }, getConfigOptions: function (a) { var b = f.utils.contextFor(a); return b || f.configuration }, setDomData: function (a, d) { var e = a[c]; e || (a[c] = e = f.utils.newId()), b[e] = d }, getDomData: function (a) { var d = a[c]; return d ? b[d] : void 0 }, contextFor: function (a) { switch (a.nodeType) { case 1: case 8: var b = f.utils.getDomData(a); if (b) return b; if (a.parentNode) return f.utils.contextFor(a.parentNode) }return void 0 }, isEmptyVal: function (a) { return void 0 === a ? !0 : null === a ? !0 : "" === a ? !0 : void 0 }, getOriginalElementTitle: function (a) { var b = f.utils.getAttribute(a, "data-orig-title"), c = a.title, d = f.utils.hasAttribute(a, "data-orig-title"); return d ? b : c }, async: function (a) { window.setImmediate ? window.setImmediate(a) : window.setTimeout(a, 0) }, forEach: function (a, b) { if (f.utils.isArray(a)) return i(a, b); for (var c in a) a.hasOwnProperty(c) && b(a[c], c) } } }(); var m = function () { function b(a) { i(a.subscriptions, function (a) { a.dispose() }), a.subscriptions = [] } function c(a) { a.options.deep && (i(a.flagged, function (a) { delete a.__kv_traversed }), a.flagged.length = 0), a.options.live || b(a) } function d(a, d) { d.validatables = [], b(d), e(a, d), c(d) } function e(b, c, d) { var f = [], g = b.peek ? b.peek() : b; b.__kv_traversed !== !0 && (c.options.deep && (b.__kv_traversed = !0, c.flagged.push(b)), d = void 0 !== d ? d : c.options.deep ? 1 : -1, a.isObservable(b) && (b.errors || n.isValidatable(b) || b.extend({ validatable: !0 }), c.validatables.push(b), c.options.live && n.isObservableArray(b) && c.subscriptions.push(b.subscribe(function () { c.graphMonitor.valueHasMutated() }))), g && !g._destroy && (n.isArray(g) ? f = g : n.isObject(g) && (f = n.values(g))), 0 !== d && n.forEach(f, function (b) { !b || b.nodeType || a.isComputed(b) && !b.rules || e(b, c, d + 1) })) } function k(a) { var b = []; return i(a, function (a) { n.isValidatable(a) && !a.isValid() && b.push(a.error.peek()) }), b } var l = 0, m = f.configuration, n = f.utils; return { init: function (a, b) { l > 0 && !b || (a = a || {}, a.errorElementClass = a.errorElementClass || a.errorClass || m.errorElementClass, a.errorMessageClass = a.errorMessageClass || a.errorClass || m.errorMessageClass, j(m, a), m.registerExtenders && f.registerExtenders(), l = 1) }, reset: f.configuration.reset, group: function (b, c) { c = j(j({}, m.grouping), c); var e = { options: c, graphMonitor: a.observable(), flagged: [], subscriptions: [], validatables: [] }, f = null; return f = c.observable ? a.computed(function () { return e.graphMonitor(), d(b, e), k(e.validatables) }) : function () { return d(b, e), k(e.validatables) }, f.showAllMessages = function (a) { void 0 === a && (a = !0), f.forEach(function (b) { n.isValidatable(b) && b.isModified(a) }) }, f.isAnyMessageShown = function () { var a; return a = !!f.find(function (a) { return n.isValidatable(a) && !a.isValid() && a.isModified() }) }, f.filter = function (a) { return a = a || function () { return !0 }, f(), g.arrayFilter(e.validatables, a) }, f.find = function (a) { return a = a || function () { return !0 }, f(), g.arrayFirst(e.validatables, a) }, f.forEach = function (a) { a = a || function () { }, f(), i(e.validatables, a) }, f.map = function (a) { return a = a || function (a) { return a }, f(), g.arrayMap(e.validatables, a) }, f._updateState = function (a) { if (!n.isObject(a)) throw new Error("An object is required."); return b = a, c.observable ? void e.graphMonitor.valueHasMutated() : (d(a, e), k(e.validatables)) }, f }, formatMessage: function (a, b, c) { if (n.isObject(b) && b.typeAttr && (b = b.value), "function" == typeof a) return a(b, c); var d = h(b); return null == d && (d = []), n.isArray(d) || (d = [d]), a.replace(/{(\d+)}/gi, function (a, b) { return "undefined" != typeof d[b] ? d[b] : a }) }, addRule: function (a, b) { a.extend({ validatable: !0 }); var c = !!g.arrayFirst(a.rules(), function (a) { return a.rule && a.rule === b.rule }); return c || a.rules.push(b), a }, addAnonymousRule: function (a, b) { void 0 === b.message && (b.message = "Error"), b.onlyIf && (b.condition = b.onlyIf), f.addRule(a, b) }, addExtender: function (b) { a.extenders[b] = function (a, c) { return c && (c.message || c.onlyIf) ? f.addRule(a, { rule: b, message: c.message, params: n.isEmptyVal(c.params) ? !0 : c.params, condition: c.onlyIf }) : f.addRule(a, { rule: b, params: c }) } }, registerExtenders: function () { if (m.registerExtenders) for (var b in f.rules) f.rules.hasOwnProperty(b) && (a.extenders[b] || f.addExtender(b)) }, insertValidationMessage: function (a) { var b = document.createElement("SPAN"); return b.className = n.getConfigOptions(a).errorMessageClass, n.insertAfter(a, b), b }, parseInputValidationAttributes: function (a, b) { i(f.configuration.html5Attributes, function (c) { if (n.hasAttribute(a, c)) { var d = a.getAttribute(c) || !0; if ("min" === c || "max" === c) { var e = a.getAttribute("type"); "undefined" != typeof e && e || (e = "text"), d = { typeAttr: e, value: d } } f.addRule(b(), { rule: c, params: d }) } }); var c = a.getAttribute("type"); i(f.configuration.html5InputTypes, function (a) { a === c && f.addRule(b(), { rule: "date" === a ? "dateISO" : a, params: !0 }) }) }, writeInputValidationAttributes: function (b, c) { var d = c(); if (d && d.rules) { var e = d.rules(); i(f.configuration.html5Attributes, function (c) { var d = g.arrayFirst(e, function (a) { return a.rule && a.rule.toLowerCase() === c.toLowerCase() }); d && a.computed({ read: function () { var e = a.unwrap(d.params); "pattern" === d.rule && e instanceof RegExp && (e = e.source), b.setAttribute(c, e) }, disposeWhenNodeIsRemoved: b }) }), e = null } }, makeBindingHandlerValidatable: function (b) { var c = a.bindingHandlers[b].init; a.bindingHandlers[b].init = function (b, d, e, f, g) { return c(b, d, e, f, g), a.bindingHandlers.validationCore.init(b, d, e, f, g) } }, setRules: function (b, c) { var d = function (b, c) { if (b && c) for (var e in c) if (c.hasOwnProperty(e)) { var g = c[e]; if (b[e]) { var i = b[e], j = h(i), k = {}, l = {}; for (var m in g) g.hasOwnProperty(m) && (f.rules[m] ? k[m] = g[m] : l[m] = g[m]); if (a.isObservable(i) && i.extend(k), j && n.isArray(j)) for (var o = 0; o < j.length; o++)d(j[o], l); else d(j, l) } } }; d(b, c) } } }(); j(a.validation, m), f.rules = {}, f.rules.required = { validator: function (a, b) { var c; return void 0 === a || null === a ? !b : (c = a, "string" == typeof a && (c = String.prototype.trim ? a.trim() : a.replace(/^\s+|\s+$/g, "")), b ? (c + "").length > 0 : !0) }, message: "This field is required." }, f.rules.min = { validator: c("min"), message: "Please enter a value greater than or equal to {0}." }, f.rules.max = { validator: c("max"), message: "Please enter a value less than or equal to {0}." }, f.rules.minLength = { validator: function (a, b) { if (f.utils.isEmptyVal(a)) return !0; var c = f.utils.isNumber(a) ? "" + a : a; return c.length >= b }, message: "Please enter at least {0} characters." }, f.rules.maxLength = { validator: function (a, b) { if (f.utils.isEmptyVal(a)) return !0; var c = f.utils.isNumber(a) ? "" + a : a; return c.length <= b }, message: "Please enter no more than {0} characters." }, f.rules.pattern = { validator: function (a, b) { return f.utils.isEmptyVal(a) || null !== a.toString().match(b) }, message: "Please check this value." }, f.rules.step = { validator: function (a, b) { if (f.utils.isEmptyVal(a) || "any" === b) return !0; var c = 100 * a % (100 * b); return Math.abs(c) < 1e-5 || Math.abs(1 - c) < 1e-5 }, message: "The value must increment by {0}." }, f.rules.email = { validator: function (a, b) { return b ? f.utils.isEmptyVal(a) || b && /^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))$/i.test(a) : !0 }, message: "Please enter a proper email address." }, f.rules.date = { validator: function (a, b) { return b ? f.utils.isEmptyVal(a) || b && !/Invalid|NaN/.test(new Date(a)) : !0 }, message: "Please enter a proper date." }, f.rules.dateISO = { validator: function (a, b) { return b ? f.utils.isEmptyVal(a) || b && /^\d{4}[-/](?:0?[1-9]|1[012])[-/](?:0?[1-9]|[12][0-9]|3[01])$/.test(a) : !0 }, message: "Please enter a proper date." }, f.rules.number = { validator: function (a, b) { return b ? f.utils.isEmptyVal(a) || b && /^-?(?:\d+|\d{1,3}(?:,\d{3})+)?(?:\.\d+)?$/.test(a) : !0 }, message: "Please enter a number." }, f.rules.digit = { validator: function (a, b) { return b ? f.utils.isEmptyVal(a) || b && /^\d+$/.test(a) : !0 }, message: "Please enter a digit." }, f.rules.phoneUS = { validator: function (a, b) { return b ? f.utils.isEmptyVal(a) ? !0 : "string" != typeof a ? !1 : (a = a.replace(/\s+/g, ""), b && a.length > 9 && a.match(/^(1-?)?(\([2-9]\d{2}\)|[2-9]\d{2})-?[2-9]\d{2}-?\d{4}$/)) : !0 }, message: "Please specify a valid phone number." }, f.rules.equal = { validator: function (a, b) { var c = b; return a === f.utils.getValue(c) }, message: "Values must equal." }, f.rules.notEqual = { validator: function (a, b) { var c = b; return a !== f.utils.getValue(c) }, message: "Please choose another value." }, f.rules.unique = { validator: function (a, b) { var c = f.utils.getValue(b.collection), d = f.utils.getValue(b.externalValue), e = 0; return a && c ? (g.arrayFilter(c, function (c) { a === (b.valueAccessor ? b.valueAccessor(c) : c) && e++ }), (d ? 1 : 2) > e) : !0 }, message: "Please make sure the value is unique." }, function () { f.registerExtenders() }(), a.bindingHandlers.validationCore = function () { return { init: function (b, c) { var d = f.utils.getConfigOptions(b), e = c(); if (d.parseInputAttributes && f.utils.async(function () { f.parseInputValidationAttributes(b, c) }), d.insertMessages && f.utils.isValidatable(e)) { var g = f.insertValidationMessage(b); d.messageTemplate ? a.renderTemplate(d.messageTemplate, { field: e }, null, g, "replaceNode") : a.applyBindingsToNode(g, { validationMessage: e }) } d.writeInputAttributes && f.utils.isValidatable(e) && f.writeInputValidationAttributes(b, c), d.decorateInputElement && f.utils.isValidatable(e) && a.applyBindingsToNode(b, { validationElement: e }) } } }(), f.makeBindingHandlerValidatable("value"), f.makeBindingHandlerValidatable("checked"), a.bindingHandlers.textInput && f.makeBindingHandlerValidatable("textInput"), f.makeBindingHandlerValidatable("selectedOptions"), a.bindingHandlers.validationMessage = { update: function (b, c) { var d = c(), e = f.utils.getConfigOptions(b), i = (h(d), !1), j = !1; if (null === d || "undefined" == typeof d) throw new Error("Cannot bind validationMessage to undefined value. data-bind expression: " + b.getAttribute("data-bind")); i = d.isModified && d.isModified(), j = d.isValid && d.isValid(); var k = null; (!e.messagesOnModified || i) && (k = j ? null : d.error); var l = !e.messagesOnModified || i ? !j : !1, m = "none" !== b.style.display; e.allowHtmlMessages ? g.setHtml(b, k) : a.bindingHandlers.text.update(b, function () { return k }), m && !l ? b.style.display = "none" : !m && l && (b.style.display = "") } }, a.bindingHandlers.validationElement = { update: function (b, c, d) { var e = c(), g = f.utils.getConfigOptions(b), i = (h(e), !1), j = !1; if (null === e || "undefined" == typeof e) throw new Error("Cannot bind validationElement to undefined value. data-bind expression: " + b.getAttribute("data-bind")); i = e.isModified && e.isModified(), j = e.isValid && e.isValid(); var k = function () { var a = {}, b = !g.decorateElementOnModified || i ? !j : !1; return a[g.errorElementClass] = b, a }; a.bindingHandlers.css.update(b, k, d), g.errorsAsTitle && a.bindingHandlers.attr.update(b, function () { var a = !g.errorsAsTitleOnModified || i, c = f.utils.getOriginalElementTitle(b); return a && !j ? { title: e.error, "data-orig-title": c } : !a || j ? { title: c, "data-orig-title": null } : void 0 }) } }, a.bindingHandlers.validationOptions = function () { return { init: function (a, b) { var c = h(b()); if (c) { var d = j({}, f.configuration); j(d, c), f.utils.setDomData(a, d) } } } }(), a.extenders.validation = function (a, b) { return i(f.utils.isArray(b) ? b : [b], function (b) { f.addAnonymousRule(a, b) }), a }, a.extenders.validatable = function (b, c) { if (f.utils.isObject(c) || (c = { enable: c }), "enable" in c || (c.enable = !0), c.enable && !f.utils.isValidatable(b)) { var d = f.configuration.validate || {}, e = { throttleEvaluation: c.throttle || d.throttle }; b.error = a.observable(null), b.rules = a.observableArray(), b.isValidating = a.observable(!1), b.__valid__ = a.observable(!0), b.isModified = a.observable(!1), b.isValid = a.computed(b.__valid__), b.setError = function (a) { var c = b.error.peek(), d = b.__valid__.peek(); b.error(a), b.__valid__(!1), c === a || d || b.isValid.notifySubscribers() }, b.clearError = function () { return b.error(null), b.__valid__(!0), b }; var g = b.subscribe(function () { b.isModified(!0) }), h = a.computed(j({ read: function () { b(), b.rules(); return f.validateObservable(b), !0 } }, e)); j(h, e), b._disposeValidation = function () { b.isValid.dispose(), b.rules.removeAll(), g.dispose(), h.dispose(), delete b.rules, delete b.error, delete b.isValid, delete b.isValidating, delete b.__valid__, delete b.isModified, delete b.setError, delete b.clearError, delete b._disposeValidation } } else c.enable === !1 && b._disposeValidation && b._disposeValidation(); return b }, f.validateObservable = function (a) { for (var b, c, g = 0, h = a.rules(), i = h.length; i > g; g++)if (c = h[g], !c.condition || c.condition()) if (b = c.rule ? f.rules[c.rule] : c, b.async || c.async) e(a, b, c); else if (!d(a, b, c)) return !1; return a.clearError(), !0 }; var n, o = {}; f.defineLocale = function (a, b) { return a && b ? (o[a.toLowerCase()] = b, b) : null }, f.locale = function (a) { if (a) { if (a = a.toLowerCase(), !o.hasOwnProperty(a)) throw new Error("Localization " + a + " has not been loaded."); f.localize(o[a]), n = a } return n }, f.localize = function (a) { var b = f.rules; for (var c in a) b.hasOwnProperty(c) && (b[c].message = a[c]) }, function () { var a = {}, b = f.rules; for (var c in b) b.hasOwnProperty(c) && (a[c] = b[c].message); f.defineLocale("en-us", a) }(), n = "en-us", a.applyBindingsWithValidation = function (b, c, d) { var e, g = document.body; c && c.nodeType ? (g = c, e = d) : e = c, f.init(), e && (e = j(j({}, f.configuration), e), f.utils.setDomData(g, e)), a.applyBindings(b, g) }; var p = a.applyBindings; a.applyBindings = function (a, b) { f.init(), p(a, b) }, a.validatedObservable = function (b, c) { if (!c && !f.utils.isObject(b)) return a.observable(b).extend({ validatable: !0 }); var d = a.observable(b); return d.errors = f.group(f.utils.isObject(b) ? b : {}, c), d.isValid = a.observable(0 === d.errors().length), a.isObservable(d.errors) ? d.errors.subscribe(function (a) { d.isValid(0 === a.length) }) : a.computed(d.errors).subscribe(function (a) { d.isValid(0 === a.length) }), d.subscribe(function (a) { f.utils.isObject(a) || (a = {}), d.errors._updateState(a), d.isValid(0 === d.errors().length) }), d } });
//# sourceMappingURL=knockout.validation.min.js.map