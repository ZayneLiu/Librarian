<template>
  <div class="search-bar">
    <input
      @keypress.enter="submitSearchKeword()"
      class="form-control"
      placeholder="Enter search keyword."
      type="text"
      v-model="keyword"
    />
  </div>
</template>

<style lang='scss'>
@import url("../assets/bootstrap/bootstrap.css");
@mixin flex-row {
  display: flex;
  flex-flow: row nowrap;
}
@mixin flex-col {
  display: flex;
  flex-flow: column nowrap;
}
.search-bar {
  @include flex-col();
  align-items: center;

  margin: 10px 0;
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
    console.log(this.keyword.split(" "));
  }
}
</script>