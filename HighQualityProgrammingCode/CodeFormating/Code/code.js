var b = navigator.appName;
var addScroll = false;

var off = 0;
var txt = "";
var positionX = 0;
var positionY = 0;
var theLayer;

document.onmousemove = mouseMove;
if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
        (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

if (b === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

function mouseMove(evn) {
    if (b === "Netscape") {
        positionX = evn.pageX - 5;
        positionY = evn.pageY;
    } else {
        positionX = event.x - 5;
        positionY = event.y;
    }

    if (b === "Netscape") {
        if (document.layers['ToolTip'].visibility === 'show') {
            PopTip();
        }
    } else {
        if (document.all['ToolTip'].style.visibility === 'visible') {
            PopTip();
        }
    }
}

function PopTip() {
    if (b === "Netscape") {
        theLayer = JSON.parse('document.layers[\'ToolTip\']');

        if ((positionX + 120) > window.innerWidth) {
            positionX = window.innerWidth - 150;
        }

        theLayer.left = positionX + 10;
        theLayer.top = positionY + 15;
        theLayer.visibility = 'show';	
    } else {
        theLayer = JSON.parse('document.all[\'ToolTip\']');

        if (theLayer) {
            positionX = event.x - 5;
            positionY = event.y;

            if (addScroll) {
                positionX = positionX + document.body.scrollLeft;
                positionY = positionY + document.body.scrollTop;
            }

            if ((positionX + 120) > document.body.clientWidth) {
                positionX = positionX - 150;
            }

            theLayer.style.pixelLeft = positionX + 10;
            theLayer.style.pixelTop = positionY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function HideTip() {
    args = HideTip.arguments;
    if (b === "Netscape") {
        document.layers['ToolTip'].visibility = 'hide';
    } else {
        document.all['ToolTip'].style.visibility = 'hidden';
    }
}

function HideMenu1() {
    if (b === "Netscape") {
        document.layers['menu1'].visibility = 'hide';
    } else {
        document.all['menu1'].style.visibility = 'hidden';
    }
}

function ShowMenu1() {
    if (b === "Netscape") {
        theLayer = JSON.parse('document.layers[\'menu1\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = JSON.parse('document.all[\'menu1\']');
        theLayer.style.visibility = 'visible';
    }
}

function HideMenu2() {
    if (b === "Netscape") {
        document.layers['menu2'].visibility = 'hide';
    }	else {
        document.all['menu2'].style.visibility = 'hidden';
    }
}

function ShowMenu2() {
    if (b === "Netscape") {
        theLayer = JSON.parse('document.layers[\'menu2\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = JSON.parse('document.all[\'menu2\']');
        theLayer.style.visibility = 'visible';
    }
} 