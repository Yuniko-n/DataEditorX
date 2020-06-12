/*
 * 由SharpDevelop创建。
 * 用户： Acer
 * 日期: 5月20 星期二
 * 时间: 7:40
 * 
 */
using System.Windows.Forms;

namespace DataEditorX.Language
{
    /// <summary>
    /// 消息
    /// </summary>
    public static class MyMsg
    {
        static readonly string _info, _warning, _error, _question;
        static MyMsg()
        {
            _info = LanguageHelper.GetMsg(LMSG.titleInfo);
            _warning = LanguageHelper.GetMsg(LMSG.titleWarning);
            _error = LanguageHelper.GetMsg(LMSG.titleError);
            _question = LanguageHelper.GetMsg(LMSG.titleQuestion);
        }
        public static void Show(string strMsg)
        {
            MessageBox.Show(strMsg, _info,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Warning(string strWarn)
        {
            MessageBox.Show(strWarn, _warning,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(string strError)
        {
            MessageBox.Show(strError, _error,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Question(string strQues)
        {
            if (MessageBox.Show(strQues, _question,
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void Show(LMSG msg)
        {
            MessageBox.Show(LanguageHelper.GetMsg(msg), _info,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void Warning(LMSG msg)
        {
            MessageBox.Show(LanguageHelper.GetMsg(msg), _warning,
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        public static void Error(LMSG msg)
        {
            MessageBox.Show(LanguageHelper.GetMsg(msg), _error,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static bool Question(LMSG msg)
        {
            if (MessageBox.Show(LanguageHelper.GetMsg(msg), _question,
                               MessageBoxButtons.OKCancel,
                               MessageBoxIcon.Question) == DialogResult.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
