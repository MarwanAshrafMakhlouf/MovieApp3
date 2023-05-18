"use-strict";

const trailerModel = document.querySelector(".trailer-model");
const trailerOverlay = document.querySelector(".trailer-overlay");
const showTrailerBtns = document.querySelectorAll(".showTrailerBtn");
const closeTrailerBtn = document.querySelector(".btn--close-modal");

const showLogoutBtn = document.querySelector(".logout");
const closeLogoutBtn = document.querySelector(".cancel");
const logoutModel = document.querySelector(".logout-model");
const logoutOverlay = document.querySelector(".logout-overlay");

const toggleFilterBtn = document.querySelector(".filter");
const filteredData = document.querySelector(".filter-data ");

const searchField = document.querySelector(".searchField");
const toggleSearchBtn = document.querySelector(".fa-magnifying-glass");

const openModel = (model, overlay) => {
  model.classList.remove("hidden");
  overlay.classList.remove("hidden");
};

const closeModel = (model, overlay) => {
  model.classList.add("hidden");
  overlay.classList.add("hidden");
};

// == Start Trailer Btns ==
showTrailerBtns.forEach((btn) =>
  btn.addEventListener(
    "click",
    openModel.bind(null, trailerModel, trailerOverlay)
  )
);
closeTrailerBtn.addEventListener(
  "click",
  closeModel.bind(null, trailerModel, trailerOverlay)
);
trailerOverlay.addEventListener(
  "click",
  closeModel.bind(null, trailerModel, trailerOverlay)
);
// == End Trailer Btns ==

// == Start Logout  ==
showLogoutBtn.addEventListener(
  "click",
    windows.location.assign("~/Home/singup")
);

closeLogoutBtn.addEventListener(
  "click",
  closeModel.bind(null, logoutModel, logoutOverlay)
);

logoutOverlay.addEventListener(
  "click",
  closeModel.bind(null, logoutModel, logoutOverlay)
);
// == End Logout  ==
// == Filter ==
toggleFilterBtn.addEventListener("click", () => {
  filteredData.classList.toggle("hidden");
});
// == Filter ==
// == Search ==
toggleSearchBtn.addEventListener("click", () => {
  searchField.classList.toggle("hidden");
});
// == Search ==
