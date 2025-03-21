document.addEventListener('DOMContentLoaded', () => {
    const rainContainer = document.querySelector('.rain_container');
    for (let i = 0; i < 30; i++) {
        const raindrop = document.createElement('div');
        raindrop.classList.add('raindrop');
        raindrop.style.left = `${Math.random() * 100}%`; /* Random horizontal position */
        raindrop.style.animationDuration = `${1 + Math.random() * 2}s`; /* 1s to 3s */
        raindrop.style.animationDelay = `${Math.random() * 2}s`; /* 0s to 2s delay */
        rainContainer.appendChild(raindrop);
    }
});

Blazor.start().then(() => {
    const splash_screen = document.getElementById('splash_screen');
    splash_screen.classList.add('fade-out');
    setTimeout(() => {
        splash_screen.style.display = 'none'; /* Hide after fade-out */
    }, 500); /* Matches fadeOut animation duration */
});
