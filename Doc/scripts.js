//Add Title change when not focused
let docTitle = document.title;
window.addEventListener("blur",()=>{
    document.title = "Come back! You piece of garbage!";
})
window.addEventListener("focus",()=>{
    document.title = docTitle;
})

document.addEventListener('DOMContentLoaded', function() {
  // Get all elements with the class "card"
  var cardElements = document.querySelectorAll('#container .card .front');

  // Loop through each card element
  cardElements.forEach(function (card) {
    // Create the Edit button
    var editBtn = document.createElement('button');
    editBtn.className = 'btn btn-primary edit-btn';
    editBtn.textContent = 'Edit';

    // Create the Save button
    var saveBtn = document.createElement('button');
    saveBtn.className = 'btn btn-secondary save-btn d-none';
    saveBtn.textContent = 'Save';

    // Create a div to hold the buttons
    var btnGroup = document.createElement('div');
    btnGroup.className = 'btn-group';
    btnGroup.appendChild(editBtn);
    btnGroup.appendChild(saveBtn);

    // Append the button group to the card
    card.appendChild(btnGroup);
  });

  var editBtns= document.querySelectorAll('button[class="btn btn-primary .edit-btn"]');
  var saveBtns= document.querySelectorAll('button[class="btn btn-secondary .save-btn"]');
  console.log(editBtns);
  console.log(saveBtns);

  // Edit and save processing for each card
  editBtns.forEach(function(editBtn){
    editBtn.addEventListener('click', () => {
      saveBtns.forEach(function(saveBtn) {
        const cardTextElement = card.querySelector('.front > h2, .front > p');
        const cardText = cardTextElement.textContent;

        const inputField = document.createElement('input');
        inputField.type = 'text';
        inputField.className = 'form-control';
        inputField.value = cardText;

        cardTextElement.replaceWith(inputField);
        inputField.focus();

        saveBtn.classList.remove('d-none');
        editBtn.classList.add('d-none');

        inputField.addEventListener('blur', () => {
          const newText = inputField.value;

          const newCardTextElement = document.createElement('p');
          newCardTextElement.className = 'card-text card-editable';
          newCardTextElement.textContent = newText;

          inputField.replaceWith(newCardTextElement);

          saveBtn.classList.add('d-none');
          editBtn.classList.remove('d-none');
        });
     });
    });
  });
});
