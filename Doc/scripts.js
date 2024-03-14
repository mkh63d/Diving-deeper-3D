//#region titleChange
let docTitle = document.title;
window.addEventListener("blur",()=>{
    document.title = "Come back! You piece of garbage!";
})
window.addEventListener("focus",()=>{
    document.title = docTitle;
})
//#endregion

let fr= new FileReader();

fr.onload=function(){
  let xml = this.result;
  let parser = new DOMParser();
  let xmlDoc = parser.parseFromString(xml, "text/xml");
  let xmlRoot = xmlDoc.documentElement;

  let cardContainer = document.querySelector("#cardContainer");

  showCards(xmlRoot, cardContainer);
}

function downloadCards(xmlRoot){
  let xmlText = 'data:application/xml,<?xml version="1.0" encoding="UTF-8"?>${encodeURIComponent(xmlRoot.outerHTML)}';

  let a = document.querySelector('#downloadFile');
  a.download = a.textContent = "xmlResult.xml";
  let newxml = xmlText.replace(' xmlns="http://www.w3.org/1999/xhtml"', '');
  a.href = newxml;
  document.body.appendChild(a);
}

document.querySelector('#file').addEventListener('change',function(){
  fr.readAsText(this.files[0]);
})

function showCards(xmlRoot, cardContainer) {
  downloadCards(xmlRoot, cardContainer)
  
  let container = document.createElement('div');
  let containerClass = document.createAttribute('class');
  containerClass.value = 'card';
  container.setAttributeNode(containerClass);
  let cards = xmlRoot.querySelector('cards');

  if(cards.children[0]){
    for(let i = 0; i < cards.children.length; i++) {
      let child = cards.children[i];

      //TODO: Add img and a cases

      var cardTitle = document.createElement('h2');
      var cardText = document.createElement('p');

      cardTitle.innerHTML = child.querySelector('h2').innerHTML;
      cardText.innerHTML = child.querySelector('p').innerHTML;

      container.appendChild(cardTitle);
      container.appendChild(cardText);
    }

    cardContainer.appendChild(container);
  } else throw new Error('No cards found');
};
