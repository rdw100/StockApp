    window.getMemoryUsage = function () {
        if (performance.memory) {
            return {
                totalJSHeapSize: performance.memory.totalJSHeapSize,
                usedJSHeapSize: performance.memory.usedJSHeapSize,
                jsHeapSizeLimit: performance.memory.jsHeapSizeLimit
            };
        } else {
            return null;
        }
    };