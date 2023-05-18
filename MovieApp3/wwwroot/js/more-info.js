"use-strict";

const reviewShowBtn = document.querySelector(".reviewBtn");
const reviewModel = document.querySelector(".review-model");
const reviewOverlay = document.querySelector(".review-overlay");

const openModel = (model, overlay) => {
  model.classList.remove("hidden");
  overlay.classList.remove("hidden");
};

const closeModel = (model, overlay) => {
  model.classList.add("hidden");
  overlay.classList.add("hidden");
};

reviewShowBtn.addEventListener(
  "click",
  openModel.bind(null, reviewModel, reviewOverlay)
);

reviewOverlay.addEventListener(
  "click",
  closeModel.bind(null, reviewModel, reviewOverlay)
);

// Stars
let rating;
const form = document.querySelector(".review-form");
const stars = document.querySelectorAll(".star");

stars.forEach(function (star) {
  star.addEventListener("click", setRating);
});

function setRating(ev) {
  const clickedStar = ev.currentTarget;
  rating = clickedStar.getAttribute("data-value");

  stars.forEach(function (star) {
    if (star.getAttribute("data-value") <= rating) {
      star.classList.add("active");
    } else {
      star.classList.remove("active");
    }
  });
}


const form = document.querySelector('.review-form');
const ratingInput = document.querySelector('#rating-input');
const spoilerInputs = document.querySelectorAll('input[name="spoiler"]');

form.addEventListener('submit', function (ev) {
    ev.preventDefault();
    const rating = +ratingInput.value + 1;
    console.log('Selected rating: ' + rating);
    if (rating) {
        ratingInput.value = rating;
        // Set the value of the spoiler input based on user selection
        let spoiler = '';
        for (let i = 0; i < spoilerInputs.length; i++) {
            if (spoilerInputs[i].checked) {
                spoiler = spoilerInputs[i].value;
                break;
            }
        }
        // Submit the form data using AJAX
        const xhr = new XMLHttpRequest();
        xhr.open('POST', form.action);
        xhr.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');
        xhr.onload = function () {
            if (xhr.status === 200) {
                // Handle successful response
                console.log('Review submitted successfully');
                window.location.href = '@Url.Action("home", "Home")';
            } else {
                // Handle error response
                console.error('Error submitting review');
            }
        };
        xhr.send(`itemId=${form.elements["itemId"].value}&itemType=${form.elements["itemType"].value}&spoiler=${spoiler}&review=${form.elements["review"].value}&rating=${rating}`);
    }
});