namespace KZ.WebUI.Tool.Abstract
{
    public interface IMenuToolService
    {
        string FooterMenuList(byte languageId);

        string FooterMenuList2(byte languageId);

        string Header_GenerateMenu(byte languageId);

        string Header_GenerateAccordionMenu(byte languageId);

        string SidebarMenuList(byte languageId, bool isIcon = false);

        string Mobile_GenerateMenu(byte languageId);

        string HeaderTopMenuList(byte languageId);


        string Header_LeftGenerateMenu(byte languageId);

        string Header_RightGenerateMenu(byte languageId);


        void clearText();
    }
}
