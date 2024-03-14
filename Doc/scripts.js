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

function showCards(xmlRoot, container) {
  downloadCards(xmlRoot, container)
  
  let cards = xmlRoot.querySelector('cards');

  if(cards.children[0]){
    for(let i = 0; i < cards.children.length; i++) {
      //#region dataTake    

      let cardContainer = document.createElement('div');
      let containerClass = document.createAttribute('class');
      containerClass.value = 'card';
      cardContainer.setAttributeNode(containerClass);

      let card = cards.children[i];

      if(card.querySelector('h2') !== null) {
        var cardTitle = document.createElement('h2');
        cardTitle.innerHTML = card.querySelector('h2').innerHTML;
        cardContainer.appendChild(cardTitle);
      }

      if(card.querySelector('p') !== null) {
        var cardText = document.createElement('p');
        cardText.innerHTML = card.querySelector('p').innerHTML;
        cardContainer.appendChild(cardText);
      }
      
      if(card.querySelector('img') !== null){
        var cardImage = document.createElement('img');
        var cardImageSrc = document.createAttribute('src');
        cardImageSrc.value = card.querySelector('img').src;
        cardImage.setAttributeNode(cardImageSrc);
        cardContainer.appendChild(cardImage);
      }
      
      if(card.querySelector('a') !== null){
        var cardA = document.createElement('a');
        var cardAHref = document.createAttribute('href');
        cardAHref.value = cardA.href;
        cardA.setAttributeNode(cardAHref);
        if(cardA.querySelector('a').innerHTML !== null) {
          cardA.innerHTML = card.querySelector('a').innerHTML;
        cardContainer.appendChild(cardA);
      }}

      //#endregion dataTake


      container.appendChild(cardContainer);


    }
  }else throw new Error('No cards found');
  


};
