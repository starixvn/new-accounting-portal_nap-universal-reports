import { Response } from '@angular/http';

function saveExcel(response: Response, fileName: string) {
    const contentType = 'application/vnd.ms-excel';
    const blob = response.blob();
    if (navigator.appVersion.toString().indexOf('.NET') > 0) {
        window.navigator.msSaveBlob(blob, fileName);
    } else {
        const mouseEvent = document.createEvent('MouseEvents');
        const hyperlinkElement = document.createElement('a');
        hyperlinkElement.download = fileName;
        hyperlinkElement.href = window.URL.createObjectURL(blob);
        (<any>hyperlinkElement.dataset).downloadurl = [contentType, hyperlinkElement.download, hyperlinkElement.href].join(':');
        mouseEvent.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
        hyperlinkElement.dispatchEvent(mouseEvent);
    }
}

export let Helper = {
    saveExcel: saveExcel
};
