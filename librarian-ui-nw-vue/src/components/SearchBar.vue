<template>
  <div class="search-bar">
    <input
      @keypress.enter="submitSearchKeword()"
      class="form-control"
      placeholder="Enter search keyword."
      type="text"
      v-model="keyword"
    />
    <button @click="submitSearchKeword()" class="btn btn-primary btn-sm">Search</button>
  </div>
</template>

<style lang='scss'>
// @import url("../assets/bootstrap/bootstrap.css");
@mixin flex-row {
  display: flex;
  flex-flow: row nowrap;
}
@mixin flex-col {
  display: flex;
  flex-flow: column nowrap;
}
.search-bar {
  @include flex-row();
  // align-items: center;
  justify-content: center;
  padding: 10px 0;
  background-color: #e1e1e1;
  position: sticky;
  // width: fit-content;
  input {
    border-bottom: #616161 1px solid;
    border-radius: 10px;
    height: 26px;
    // height: px;
    padding: 2px unset;
    width: 60%;
    border: none;
  }
  button {
    margin: 0;
    margin-left: 5px;
    padding: 0 5px;
  }
}
</style>

<script lang='ts'>
import { Component, Vue } from "vue-property-decorator";
import { mitter } from "@/main";
@Component({})
export default class SearchBar extends Vue {
  public keyword: string = "";

  submitSearchKeword() {
    mitter.emit("keywordSubmission", this.keyword);
    // console.log(`keyword(s) are ${this.keyword.split(" ")}`);
    // console.log(this.keyword.split(" "));
  }
  mounted() {
    mitter.on("clear", () => {
      this.keyword = "";
    });
  }
}
</script>