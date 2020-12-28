var map = L.map('map').setView([50.049683, 19.944544], 12);

L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
}).addTo(map);

L.marker([50.068544, 20.013084]).addTo(map)
    .bindPopup('All radios in location: 0 <br><br> <button class="btn">See all radios in location</button> <br><br> <button class="btn">Report alarm</button>');

L.marker([49.9837, 20.0004]).addTo(map)
    .bindPopup('All radios in location: 0 <br><br> <button class="btn">See all radios in location</button> <br><br> <button class="btn">Report alarm</button>');

L.marker([50.0347, 19.9402]).addTo(map)
    .bindPopup('All radios in location: 0 <br><br> <button class="btn">See all radios in location</button> <br><br> <button class="btn">Report alarm</button>');

L.marker([50.0725, 19.9013]).addTo(map)
    .bindPopup('All radios in location: 0 <br><br> <button class="btn">See all radios in location</button> <br><br> <button class="btn">Report alarm</button>');