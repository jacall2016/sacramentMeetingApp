// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* ------------------------------- For Create View for Sacrament Program ---------------------------------------*/

// Add new speaker
const addTalkButtonEvent = document.getElementById("addTalkButton");
let speakerCount = 1;
if (addTalkButtonEvent) {
  document
    .getElementById("addTalkButton")
    .addEventListener("click", function () {
      const talksContainer = document.getElementById("talksContainer");
      const talkRows = talksContainer.getElementsByClassName("talk-row").length;
      const newTalkDiv = document.createElement("div");
      newTalkDiv.className =
        "row talk-row border border-primary mb-2 p-2 rounded-3";
      newTalkDiv.innerHTML = `
      <div class="d-flex justify-content-between">
          <p>Speaker N° ${talkRows + 1}</p>
          <button type="button" class="remove-talk btn-close" aria-label="Close"></button>
        </div>
      <div class="mb-3">
          <label class="form-label">Speaker Name</label>
          <select name="NewSacramentProgram.Talk[${
            talksContainer.children.length
          }].SpeakerName" class="form-select">
          <option disabled selected value="">Select a speaker</option>
              ${speakerNameOptions
                .map(
                  (option) =>
                    `<option value="${option.value}">${option.text}</option>`
                )
                .join("")}
          </select>
      </div>
      <div class="mb-3">
          <label class="form-label">Topic</label>
          <input name="NewSacramentProgram.Talk[${
            talksContainer.children.length
          }].Topic" type="text" class="form-control" />
      </div>
      <input type="hidden" name="NewSacramentProgram.Talk[${
        talksContainer.children.length
      }].IsDeleted" value="false" />
  `;
      talksContainer.appendChild(newTalkDiv);
      const removeTalkButton = newTalkDiv.querySelector(".remove-talk");
      removeTalkButton.addEventListener("click", function () {
        this.parentNode.parentNode.remove();
      });
    });
}

// Remove speaker
const removeTalkButtonEvent = document.getElementById("removeTalkButtonEvent");

if (removeTalkButtonEvent) {
  removeTalkButtonEvent.addEventListener("click", function () {
    this.parentNode.parentNode.remove();
  });
}

/* -------------------------- For Update View for Sacrament Program --------------------------------------*/

// Add new speaker in Edit View
const addTalkButtonEventUpdate = document.getElementById("addTalkButtonUpdate");

if (addTalkButtonEventUpdate) {
  addTalkButtonEventUpdate.addEventListener("click", function () {
    const talksContainer = document.getElementById("talksContainer");
    const talkRows = talksContainer.getElementsByClassName("talk-row").length;
    const newTalkDiv = document.createElement("div");
    newTalkDiv.className =
      "row talk-row border border-primary mb-2 p-2 rounded-3";
    newTalkDiv.innerHTML = `
        <div class="d-flex justify-content-between">
          <p>Speaker N° ${talkRows + 1}</p>
          <button type="button" id="removeTalkButtonEvent" class="btn-close" aria-label="Close"></button>
        </div>
        <div>
          <div class="mb-3">
            <label for="txtCity" class="form-label">Speaker Name</label>
            <select name="SacramentProgram.Talk[${talkRows}].SpeakerName" class="form-select">
              <option disabled selected value="">Select a speaker</option>
              ${speakerNameOptions
                .map(
                  (option) =>
                    `<option value="${option.value}">${option.text}</option>`
                )
                .join("")}
            </select>
          </div>
          <div class="mb-3">
            <label for="txtCity" class="form-label">Topic</label>
            <input name="SacramentProgram.Talk[${talkRows}].Topic" type="text" class="form-control" />
          </div>
          <input type="hidden" name="SacramentProgram.Talk[${talkRows}].Id" value="0" />
          <input type="hidden" name="SacramentProgram.Talk[${talkRows}].IsDeleted" value="false" />
        </div>
      `;
    talksContainer.appendChild(newTalkDiv);
  });
}

// Remove speaker in Edit View

document.addEventListener("DOMContentLoaded", function () {
  document.addEventListener("click", function (event) {
    if (event.target.matches(".remove-talk")) {
      const row = event.target.closest(".talk-row");
      row.querySelector('input[name$="IsDeleted"]').value = "true";
      row.style.display = "none";
    }
  });
});

/* -------------------------- For Create View for Hymns --------------------------------------*/
$(document).ready(function () {
  $(".NewSacramentProgram_Hyms").select2({
    ajax: {
      url: "/SacramentPlanner/Create?handler=Hymns",
      dataType: "json",
      delay: 250,
      data: function (params) {
        return {
          q: params.term, // search term
          page: params.page || 1,
        };
      },
      processResults: function (data, params) {
        return {
          results: data.items,
          pagination: {
            more: params.page * 50 < data.total_count,
          },
        };
      },
      cache: true,
    },
    minimumInputLength: 1,
  });
});
