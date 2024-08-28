import { defineStore } from 'pinia';
import { reactive, ref } from 'vue';

export const useSearchResultsStoreForTrain = defineStore('searchResultsForTrain', () => {
  const searchResultsForTrain = reactive([])

  let index = 0

  function setsearchResultsForTrain(newResults) {
    searchResultsForTrain.splice(0, searchResultsForTrain.length, ...newResults);
    console.log(searchResultsForTrain);
  }


  return { searchResultsForTrain, setsearchResultsForTrain, index }

});
