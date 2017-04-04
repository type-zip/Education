var myImage = document.querySelector('img');

myImage.onclick = function() {
    var mySrc = myImage.getAttribute('src');

    if(mySrc === 'images/logo.svg') {
        myImage.setAttribute('src', 'images/gitlab_logo.png'); 
    }
    else {
        myImage.setAttribute('src', 'images/logo.svg');
    };
}

var myButton = document.querySelector('button');
var myHeading = document.querySelector('h1');

function setUserName()
{
    var myName = prompt("Please enter your name.");
    localStorage.setItem('name', myName);
    myHeading.textContent = 'Welcome to the test page, ' + myName;
}


if(!localStorage.getItem('name')) {
    setUserName();
} else {
    var storedName = localStorage.getItem('name');
    myHeading.textContent = "Welcome to the test page, " + storedName;
}

myButton.onclick = function() { setUserName(); }