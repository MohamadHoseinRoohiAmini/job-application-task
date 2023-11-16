using static com.google.i18n.phonenumbers.PhoneNumberUtil;

namespace Mc2.CrudTest.Application.Contracts.Extensions
{
    public static class ValidatePhone
    {
        public static bool MethodValidate(string phoneNumer)
        {
            var _phoneNumberUtil = com.google.i18n.phonenumbers.PhoneNumberUtil.getInstance();
            try
            {
                var number = _phoneNumberUtil.parse(phoneNumer, string.Empty); // can be any country
                var getType = _phoneNumberUtil.getNumberType(number);
                if (!_phoneNumberUtil.isValidNumber(number) || getType != PhoneNumberType.MOBILE)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (com.google.i18n.phonenumbers.NumberParseException)
            {
                return false;
            }
        }
    }
}