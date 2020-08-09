<template>
  <div class="result-view">
    <div class="no-result" v-if="searchResult.length == 0 && keyword !==''">
      No result for keyword:
      <i>"{{keyword}}"</i>
      <slot></slot>
    </div>
    <div class="init" v-else-if="keyword == ''">Please Enter Search Keyword.</div>
    <template v-else>
      <div class="result-info">
        <span>Search result: {{searchResult.length}} hit(s)</span>
        <slot></slot>
      </div>
      <div :key="index" class="result-item" v-for="(item, index) in searchResult">
        <div class="doc-name">{{item.name}}</div>
        <div class="doc-path">{{item.path}}</div>
        <div class="keyword-occurrence">{{item.result}}</div>
      </div>
    </template>
  </div>
</template>

<style lang='scss'>
@mixin flex-row {
  display: flex;
  flex-flow: row nowrap;
}
@mixin flex-col {
  display: flex;
  flex-flow: column nowrap;
}
.result-view {
  flex: 1;
  @include flex-col();
  background-color: #fff;

  align-items: flex-start;
  text-align: start;
  padding: 5px;
  //DEBUG
  // justify-content: center;
  // background-color: aquamarine;
  button {
    margin: 0;
    padding: 0 5px;
  }
  .init {
    // text-align: center;
    align-self: center;
  }
  .no-result {
    align-self: center;
    font-size: 20px;
  }
  .result-info {
    width: 100%;
    @include flex-row();

    justify-content: center;
    margin: 3px 0;
    button {
      margin-left: 30px;
    }
  }
  .result-item {
    width: 100%;
    box-sizing: border-box;
    padding: 5px;
    border: #d1d1d1 1px solid;
    border-radius: 5px;
    margin-top: 5px;
  }

  .doc-name::before {
    content: "Name: ";
    background-color: #d1d1d1;
    padding: 1px 2px;
    border-radius: 5px;
    margin-right: 5px;
  }
  .doc-path::before {
    content: "Path: ";
    background-color: #d1d1d1;
    padding: 1px 2px;
    border-radius: 5px;
    margin-right: 5px;
  }
  .keyword-occurrence::before {
    content: "Occurrence: ";
    background-color: #d1d1d1;
    padding: 1px 2px;
    border-radius: 5px;
    margin-right: 5px;
  }
}
</style>

<script lang='ts'>
import { Component, Vue, Prop } from "vue-property-decorator";
@Component({})
export default class ResultView extends Vue {
  @Prop({ default: [] })
  public searchResult!: [];
  @Prop({ default: "" })
  public keyword!: "";
}
</script>