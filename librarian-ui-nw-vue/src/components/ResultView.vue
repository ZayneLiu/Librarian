<template>
  <div class="result-view">
    <span>Search result of "{{keyword}}"</span>
    ResultView
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

  //DEBUG
  justify-content: center;
  background-color: aquamarine;
}
</style>

<script lang='ts'>
import { Component, Vue, Prop } from "vue-property-decorator";
@Component({})
export default class ResultView extends Vue {
  @Prop({ default: "" })
  public keyword!: string;
}
</script>