const startTime = Date.now();
const minimum_splash_screen_time = 3000;

Blazor.start().then(() => {
    const elapsedTime = Date.now() - startTime;
    const remainingTime = minimum_splash_screen_time - elapsedTime;
    
    const fadeOut = () => {
        const splash_screen = document.getElementById('splash_screen');
        splash_screen.classList.add('fade-out');
        setTimeout(() => {
            splash_screen.style.display = 'none'; /* Hide after fade-out */
        }, 500); /* Matches fadeOut animation duration */
    };
    
    if (remainingTime > 0) {
        setTimeout(fadeOut, remainingTime);
    } else {
        fadeOut();
    }
}).catch(error => {
    console.error('Blazor failed to start:', error);
});
