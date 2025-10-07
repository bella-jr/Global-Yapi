using CKEditor.NET;

namespace KZ.WebUI.Tool.Abstract
{
    internal interface ICkEditorService
    {
        void StandartAyarlar(CKEditorControl editor);
        void StandartAyarlar(CKEditorControl editor, string klasor);
        void Ayarla(CKEditorControl editor);

        void BasitAyarlar(CKEditorControl editor);

        object[] FullToolbar { get; }

        object[] AdminEditorToolbar { get; }

        object[] BasitToolbar { get; }

    }
}
