<template>
  <div class="folder-list">
    <span class="folders-counter">{{pathList.length}} folder(s) in total.</span>
    <div :key="index" class="folder-list-item" v-for="(folder, index) in pathList">
      <svg fill="currentColor" viewBox="0 0 16 16" xmlns="http://www.w3.org/2000/svg">
        <path
          d="M9.828 4a3 3 0 0 1-2.12-.879l-.83-.828A1 1 0 0 0 6.173 2H2.5a1 1 0 0 0-1 .981L1.546 4h-1L.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3v1z"
        />
        <path
          d="M13.81 4H2.19a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91h10.348a1 1 0 0 0 .995-.91l.637-7A1 1 0 0 0 13.81 4zM2.19 3A2 2 0 0 0 .198 5.181l.637 7A2 2 0 0 0 2.826 14h10.348a2 2 0 0 0 1.991-1.819l.637-7A2 2 0 0 0 13.81 3H2.19z"
          fill-rule="evenodd"
        />
      </svg>
      <div :title="folder.folderPath" class="path-container">
        <!-- <span>{{folder}}</span> -->
        <span>.../{{folder.folderName}}</span>
      </div>
    </div>
  </div>
</template>

<style lang='scss' scoped>
.folder-list {
  background-color: #fff;
  flex: 1;
  display: flex;
  flex-flow: column nowrap;
  .folders-counter {
    font-size: 12px;
    border-bottom: 1px solid #a1a1a1;
  }
  .folder-list-item {
    display: flex;
    flex-flow: row nowrap;
    text-align: start;
    width: 100%;
    max-width: 200px;
    font-weight: 500;
    justify-content: flex-start;
    align-items: center;
    // background-color: lightgray;
    padding: 5px;
    border-bottom: #a1a1a1 0.5px solid;
    cursor: pointer;
    user-select: none;

    &:hover {
      background-color: whitesmoke;
    }
    svg {
      flex: 1;
    }
    .path-container {
      flex: 9;
      overflow: hidden;
      white-space: nowrap;
      text-overflow: ellipsis;
      margin-left: 15px;
      // direction: rtl;
    }
  }
}
</style>

<script lang='ts'>
import { Component, Vue, Prop } from "vue-property-decorator";
@Component({})
export default class FolderList extends Vue {
  @Prop({ default: () => [] })
  public pathList!: { folderName: string; folderPath: string }[];
}
</script>