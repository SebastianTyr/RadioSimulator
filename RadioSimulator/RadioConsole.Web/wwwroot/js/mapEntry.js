///SECTION I - Creating entry map////////
var map = L.map('radioMap').setView([50.049683, 19.944544], 12);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

///SECTION II - Creating three markers - for police office, emergency and fire brigade////////
var police = L.marker([50.068544, 20.013084]).addTo(map);

var emergency = L.marker([50.0347, 19.9402]).addTo(map)

var fireBrigade = L.marker([50.0725, 19.9013]).addTo(map)

///SECTION IIII - Handling map routing////////
function policeMarker() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.068544, 20.013084),
            L.latLng(50.055701, 19.977236)
        ],
        routeWhileDragging: true,
        createMarker: function marker(i, wp, n) {
            return L.marker(L.latLng(50.055701, 19.977236), { draggable: 'true' }).addTo(map)
                .bindPopup("");
        }
    }).addTo(map);
}

function emergencyMarker() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.0347, 19.9402),
            L.latLng(50.059485, 19.942185)
        ],
        routeWhileDragging: true,
        createMarker: function marker(i, wp, n) {
            return L.marker(L.latLng(50.059485, 19.942185), { draggable: 'true' }).addTo(map)
                .bindPopup("");
        }
    }).addTo(map);
}

function fireMarker() {
    L.Routing.control({
        waypoints: [
            L.latLng(50.0725, 19.9013),
            L.latLng(50.016200, 19.890223)
        ],
        routeWhileDragging: true,
        createMarker: function marker(i, wp, n) {
            return L.marker(L.latLng(50.016200, 19.890223), { draggable: 'true' }).addTo(map)
                .bindPopup("");
        }
    }).addTo(map);
}

///SECTION IV - Binding popups with alarm functions////////
var policeAlarm = $('<div>Police Office <br><br> <button id="policeReport" class="btn">Report alarm</button></div>').click(function () {
    policeMarker();
})[0];

police.bindPopup(policeAlarm);

var emergencyAlarm = $('<div>Emergency <br><br> <button id="emergencyReport" class="btn">Report alarm</button></div>').click(function () {
    emergencyMarker();
})[0];

emergency.bindPopup(emergencyAlarm);

var fireAlarm = $('<div>Fire Brigade <br><br> <button id="fireReport" class="btn">Report alarm</button></div>').click(function () {
    fireMarker();
})[0];

fireBrigade.bindPopup(fireAlarm);