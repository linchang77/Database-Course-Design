import { defineStore } from 'pinia';
import { reactive, ref } from 'vue';

export const useSearchResultsStoreForBus = defineStore('searchResultsForBus', () => {
  const searchResultsForBus = reactive([  ])

  let index = 0

  function setsearchResultsForBus(newResults) {
    searchResultsForBus.splice(0, searchResultsForBus.length, ...newResults);
    console.log(searchResultsForBus);
  }


  return { searchResultsForBus, setsearchResultsForBus, index }

});
