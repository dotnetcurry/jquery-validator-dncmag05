$(function ()
{
    jQuery.validator.unobtrusive.adapters.add
        ('dynamicmaxlength', ['validationfield', 'datalengthfield', 'returnfield'], function (options)
        {
            var attribs = {
                validationfield: options.params.validationfield,
                datalengthfield: options.params.datalengthfield,
                returnfield: options.params.returnfield
            };

            options.rules['dynamicmaxlength'] = attribs;

            if (options.message)
            {
                options.messages['dynamicmaxlength'] = options.message;
            }
        });

    jQuery.validator.addMethod('dynamicmaxlength', function (value, element, param)
    {
        var validationFieldSelector = '#' + param.validationfield + ' option:selected'
        var requiredLength = $(validationFieldSelector).attr(param.datalengthfield);
        if ($(element).val().length != requiredLength)
        {
            return false;
        }
        else
        {
            $('#' + param.returnfield).val(requiredLength);
            return true;
        }
    });

}(jQuery));