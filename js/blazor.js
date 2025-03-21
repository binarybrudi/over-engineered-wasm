Blazor.start().then(() => {
    const splash_screen = document.getElementById('splash_screen');
    splash_screen.classList.add('fade-out');
    setTimeout(() => {
        splash_screen.style.display = 'none'; /* Hide after fade-out */
    }, 500); /* Matches fadeOut animation duration */
}).catch(error => {
    console.error('Blazor failed to start:', error);
});
