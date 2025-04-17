export function initCanvas(canvas, dotNetRef) {
    const ctx = canvas.getContext('2d', { alpha: false });
    ctx.imageSmoothingEnabled = false;

    // create a resizeObserver to handle window/container resizing
    const resizeObserver = new ResizeObserver(entries => {
        for (const entry of entries) {
            const { width, height } = entry.contentRect;
            canvas.width = width;
            canvas.height = height;
            dotNetRef.invokeMethodAsync('NotifyCanvasResize', width, height);
        }
    });

    // start observing the canvas for size changes
    resizeObserver.observe(canvas.parentElement);

    // store the observer in the canvas element for cleanup
    canvas._resizeObserver = resizeObserver;
}
