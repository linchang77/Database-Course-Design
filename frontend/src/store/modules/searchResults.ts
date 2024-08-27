import { defineStore } from 'pinia';
import { reactive, ref } from 'vue';

export const useSearchResultsStore = defineStore('searchResults', () => {
  const searchResults = reactive([

  ])

  let index = 0

  function setSearchResults(newResults) {
    searchResults.splice(0, searchResults.length, ...newResults);
    console.log(searchResults);
  }


  return { searchResults, setSearchResults, index }

});
