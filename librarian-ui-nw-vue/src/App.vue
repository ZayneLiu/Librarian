<template>
  <div id="app">
    <div class="no-connection-modal" v-show="!connection">Pending connection to API Server</div>
    <aside>
      <add-folder-button />
      <folder-list :pathList="folderList" />
    </aside>
    <main>
      <search-bar />
      <result-view :keyword="searchKeyword" :searchResult="searchResult">
        <slot>
          <button @click="clear()" class="btn btn-secondary btn-sm">Clear</button>
        </slot>
      </result-view>
    </main>
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
import { mitter } from "./main";
import Axios, { AxiosError } from "axios";

import HelloWorld from "./components/HelloWorld.vue";
import AddFolderButton from "./components/AddFolderButton.vue";
import FolderList from "./components/FolderList.vue";
import SearchBar from "./components/SearchBar.vue";
import ResultView from "./components/ResultView.vue";

@Component({
  components: {
    HelloWorld,
    AddFolderButton,
    FolderList,
    SearchBar,
    ResultView,
  },
})
export default class App extends Vue {
  public folderList: { folderName: string; folderPath: string }[] = [];
  public searchKeyword: string = "";
  public searchResult: {} = {};
  public connection: boolean = false;

  mounted() {
    mitter.on("folderSelected", (path) => {
      if (!path) return;
      if (this.folderList.indexOf(path) >= 0) {
        alert("folder already selected!");
        return;
      }
      // TODO: API
      this.folderList.push(path);
    });

    mitter.on("keywordSubmission", (keyword) => {
      this.searchKeyword = keyword;
      //TODO: Submit keyword
      console.log(keyword);
      Axios({
        method: "POST",
        url: "https://localhost:5001/search",
        params: { keyword: keyword },
      }).then((res) => {
        this.searchResult = res.data;
      });
    });

    this.loadIndexedFolders();
    // API Server connectivity monitor.
    setInterval(this.loadIndexedFolders, 1500);
  }

  loadIndexedFolders() {
    Axios({
      method: "GET",
      url: "https://localhost:5001/folders",
    })
      .then((res) => {
        this.connection = true;
        this.folderList = res.data;
      })
      .catch((err: AxiosError) => {
        if (err.message == "Network Error") this.connection = false;
      });
  }
  clear() {
    mitter.emit("clear");
    this.searchKeyword = "";
    this.searchResult = "";
  }
}
</script>

<style lang="scss">
@import url("assets/bootstrap/bootstrap.css");

@mixin flex-row {
  display: flex;
  flex-flow: row nowrap;
}
@mixin flex-col {
  display: flex;
  flex-flow: column nowrap;
}
* {
  // transition: all 0.2s cubic-bezier(0.39, 0.575, 0.565, 1);
}
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  height: 100vh;

  // margin-top: 60px;
  background-color: transparent;
  z-index: 999;
  @include flex-row();

  .no-connection-modal {
    position: absolute;
    height: 100vh;
    line-height: 100vh;
    font-size: 30px;
    width: 100vw;
    z-index: 9;
    background: rgba($color: #e2e2e2, $alpha: 0.5);
    backdrop-filter: blur(2px);
  }
  //   position: absolute;
  //   width: 100vw;
  //   height: 100vh;
  //   // filter: blur(10px);
  //   background-color: rgba(100, 100, 100, 0.9);
  //   z-index: -1;
  // }
  main {
    @include flex-col();
    // background-color: lightcoral;
    flex: 2;
    z-index: 1;
    border-left: black 1px solid;
  }
  aside {
    @include flex-col();
    overflow: visible;
    // background-color: lightblue;
    max-width: 200px;
    padding: 0;
    flex: 1;
    // border-left: grey 0.5px solid;
    // box-shadow: #00000080 2px 0 5px 2px;
    z-index: 2;

    // appearance: none;;
    // backdrop-filter: ;
  }
}
</style>
