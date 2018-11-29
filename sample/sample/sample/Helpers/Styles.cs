using Xamarin.Forms;

namespace Sample
{
    public static class Styles
    {

        public static Color _blackTextColor = Color.FromHex("#30383B");
        public static Color _grayTextcolor = Color.FromHex("#AAB1B3");

        public static Color BlackTextColor => _blackTextColor;
        public static Color GrayTextColor => _grayTextcolor;

        #region Login

        public static Color _loginBackgroundColor = Color.FromHex("#444444");
        public static Color _loginLabelColor = Color.FromHex("#30383B");
        public static Color _loginButtonTextColor = Color.FromHex("#000000");
        public static Color _loginSeparatorColor = Color.FromHex("#EBEBEB");


        public static Color LoginBackgroundColor => _loginBackgroundColor;
        public static Color LoginLabelColor => _loginLabelColor;
        public static Color LoginButtonTextColor => _loginButtonTextColor;
        public static Color LoginSeparatorColor => _loginSeparatorColor;
        #endregion


        #region Defaults

        public static Color _defaultBackground = Color.FromHex("#FF000000");
        public static Color _defaultHomeBackground = Color.FromHex("#D8D8D8");
        public static Color _mainHorizontalListBackground = Color.FromHex("#FF222222");
        public static Color _mainVerticalListBackground = Color.FromHex("#FF333333");

        public static Color _productListBackground = Color.FromHex("#FF444444");
        public static Color _mainProductHeaderGradTop = Color.FromHex("#FF111111");
        public static Color _mainProductHeaderGradBot = Color.FromHex("#FF333333");
        public static Color _exitButtonBackground = Color.FromHex("#22FFFFFF");

        public static Color _buttonEnabled = Color.FromHex("#FFF55131");
        public static Color _buttonDisabled = Color.FromHex("#FF444444");
        public static Color _buttonHighlighted = Color.FromHex("#FFFF9933");
        public static Color _buttonGray = Color.FromHex("#FF333333");
        public static Color _buttonGrayHighlighted = Color.FromHex("#FF666666");
        public static Color _buttonGreen = Color.FromHex("#FF009900");
        
        public static Color _labelRequestColor = Color.FromHex("#FF2886E5");

        public static Color _headerDetailBackgroundColor = Color.FromHex("#FF111111");


        public static Color DefaultBackground => _defaultBackground;
        public static Color DefaultHomeBackground => _defaultHomeBackground;

        public static Color MainHorizontalListBackground => _mainHorizontalListBackground;
        public static Color MainVerticalListBackground => _mainVerticalListBackground;
        public static Color ProductListBackground => _productListBackground;
        public static Color MainProductHeaderGradTop => _mainProductHeaderGradTop;
        public static Color MainProductHeaderGradBot => _mainProductHeaderGradBot;
        public static Color ExitButtonBackground => _exitButtonBackground;
        public static Color ButtonEnabled => _buttonEnabled;
        public static Color ButtonDisabled => _buttonDisabled;
        public static Color ButtonHighlighted = _buttonHighlighted;
        public static Color ButtonGray = _buttonGray;
        public static Color ButtonGreen = _buttonGreen;
        public static Color ButtonGrayHighlighted = _buttonGrayHighlighted;

        public static Color LabelRequestColor => _labelRequestColor;
        public static Color HeaderDetailBackgroundColor => _headerDetailBackgroundColor;



        #endregion
    }
}
