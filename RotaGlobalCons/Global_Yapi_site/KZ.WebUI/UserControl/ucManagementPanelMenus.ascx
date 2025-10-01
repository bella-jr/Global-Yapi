<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucManagementPanelMenus.ascx.cs" Inherits="KZ.WebUI.UserControl.ucManagementPanelMenus" %>

<div class="sidebar sidebar-hide-to-small sidebar-shrink sidebar-gestures">
    <div class="nano">
        <div class="nano-content">
            <ul>
                <li><a href="/<%= Resources.value.url_Folder %>" target="_blank">
                    <img src="assets/images/menu_icons/external1.png" />
                    Siteye Git </a></li>
                <li><a href="Dashboard">
                    <img src="assets/images/menu_icons/dashboard.png" />
                    Dashboard </a></li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/admin.png" />Admin Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="AdminAdd">Yeni Ekle</a></li>
                        <li><a href="AdminList">Düzenle & Sil</a></li>
                    </ul>
                </li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/menu.png" />Menü Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="MenuAdd">Yeni Ekle</a></li>
                        <li><a href="MenuList">Düzenle & Sil</a></li>
                        <li><a href="MenuShort">Sıralama</a></li>
                    </ul>
                </li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/property.png" />Proje Özellik Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li>
                            <a href="PropertyGroupList">Özellik Grup Yönetim</a>
                        </li>
                        <li>
                            <a class="sidebar-sub-toggle" href="#">Özellik Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                            <ul>
                                <li><a href="PropertyList">Ekle & Düzenle & Sil</a></li>
                                <li><a href="PropertyShort">Sıralama</a></li>
                            </ul>
                        </li>
                    </ul>
                </li>


                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/product.png" />Proje Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="ProductAdd">Yeni Ekle</a></li>
                        <li><a href="ProductList">Düzenle & Sil</a></li>
                        <li><a href="ProductShort">Sıralama</a></li>
                    </ul>
                </li>

                <%--<li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/filter.png" />Referans Filtre Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="ReferenceCategoryAdd">Yeni Ekle</a></li>
                        <li><a href="ReferenceCategoryList">Düzenle & Sil</a></li>
                        <li><a href="ReferenceCategoryShort">Sıralama</a></li>
                    </ul>
                </li>--%>

                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/reference.png" />Referans Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="ReferenceAdd">Yeni Ekle</a></li>
                        <li><a href="ReferenceList">Düzenle & Sil</a></li>
                        <li><a href="ReferenceShort">Sıralama</a></li>
                    </ul>
                </li>

                <%--<li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/question.png" />SSS Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="SssAdd">Yeni Ekle</a></li>
                        <li><a href="SssList">Düzenle & Sil</a></li>
                    </ul>
                </li>--%>
                <%--<li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/search.png" />Çok Aranan Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="MostSearchedAdd">Yeni Ekle</a></li>
                        <li><a href="MostSearchedList">Düzenle & Sil</a></li>
                    </ul>
                </li>--%>
                <%-- <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/filter.png" />Tab Filtre Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="TabFilterList">Ekle & Düzenle & Sil</a></li>
                        <li><a href="TabFilterShort">Sıralama</a></li>
                    </ul>
                </li>--%>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/article.png" />Yazı Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="ArticleAdd">Yeni Ekle</a></li>
                        <li><a href="ArticleList">Düzenle & Sil</a></li>
                    </ul>
                </li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/gallery.png" />Galeri Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="GalleryAdd">Yeni Ekle</a></li>
                        <li><a href="GalleryList">Düzenle & Sil</a></li>
                        <%--<li><a href="GalleryShort">Sıralama</a></li>--%>
                    </ul>
                </li>
                <%--<li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/external.png" />Bağımsız Yazı Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="ExternalArticleAdd">Yeni Ekle</a></li>
                        <li><a href="ExternalArticleList">Düzenle & Sil</a></li>
                    </ul>
                </li>--%>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/news.png" />Blog Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="BlogAdd">Yeni Ekle</a></li>
                        <li><a href="BlogList">Düzenle & Sil</a></li>
                        <%--<li><a href="BlogShort">Sıralama</a></li>--%>
                    </ul>
                </li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/slider.png" />Slider Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="SliderAdd">Yeni Ekle</a></li>
                        <li><a href="SliderList">Düzenle & Sil</a></li>
                        <li><a href="SliderShort">Sıralama</a></li>
                    </ul>
                </li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/comment.png" />Yorum Yönetim<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="CommentAdd">Yeni Ekle</a></li>
                        <li><a href="CommentList">Düzenle & Sil</a></li>
                    </ul>
                </li>
                <li>
                    <a class="sidebar-sub-toggle">
                        <img src="assets/images/menu_icons/genel.png" />Genel Ayarlar<span class="sidebar-collapse-icon ti-angle-down"></span></a>
                    <ul>
                        <li><a href="HomePageContentUpdate">Anasayfa İçerik Düzenle</a></li>
                        <li><a href="MailSettingUpdate">Mail Sunucu Ayarları</a></li>
                        <li><a href="GeneralSettingUpdate">Sayfa Genel Ayarları</a></li>
                        <li><%--<a href="PopupManagement">Popup Yönetim</a>--%></li>
                        <li><a href="SeoPageList">Sayfa Seo Yönetim</a></li>
                    </ul>
                </li>
                <li>
                    <a href="LoginLogs">
                        <img src="assets/images/menu_icons/islem.png" />Giriş Kayıtları</a>
                </li>
            </ul>
        </div>
    </div>
</div>
