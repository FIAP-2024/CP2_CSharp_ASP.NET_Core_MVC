function toggleMenu() {
    const menuItemsContent = document.querySelector('.menu-items-content');

    if (menuItemsContent.classList.contains('menu-mobile-active')) {
        menuItemsContent.classList.remove('menu-mobile-active');
    } else {
        menuItemsContent.classList.add('menu-mobile-active');
    }
}
