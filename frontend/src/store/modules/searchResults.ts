import { defineStore } from 'pinia';
import { reactive, ref } from 'vue';

export const useSearchResultsStore = defineStore('searchResults', () => {
  const searchResults = reactive([
    {
    "vehicleId": "2024",
    "vehicleType": "plane",
    "vehicleModel": "波音373(中)",
    "departureCity": "上海",
    "arrivalCity": "北京",
    "departureTime": "2024-08-18T08:10:00",
    "arrivalTime": "2024-08-18T10:35:00",
    "departureStation": "浦东国际机场T1",
    "arrivalStation": "大兴国际机场",
    "ticketId": 6.0,
    "ticketType": "经济舱",
    "ticketPrice": 1479.0,
    "ticketRemaining": 100.0
    }
  ])

  let index = 0

  function setSearchResults(newResults) {
    searchResults.splice(0, searchResults.length, ...newResults);
    console.log(searchResults);
  }


  return { searchResults, setSearchResults, index }

});
