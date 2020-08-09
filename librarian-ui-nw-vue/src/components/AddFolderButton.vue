<template>
  <div @click="addFolder()" class="btn-add-folder btn btn-primary">
    <input
      @change="selectorOnChange()"
      id="folderSelector"
      nwdirectory
      style="display:none"
      title="Add Folder"
      type="file"
    />
    <svg
      class="bi bi-folder-plus"
      fill="currentColor"
      height="1em"
      viewBox="0 0 16 16"
      width="1em"
      xmlns="http://www.w3.org/2000/svg"
    >
      <path
        d="M9.828 4H2.19a1 1 0 0 0-.996 1.09l.637 7a1 1 0 0 0 .995.91H9v1H2.826a2 2 0 0 1-1.991-1.819l-.637-7a1.99 1.99 0 0 1 .342-1.31L.5 3a2 2 0 0 1 2-2h3.672a2 2 0 0 1 1.414.586l.828.828A2 2 0 0 0 9.828 3h3.982a2 2 0 0 1 1.992 2.181L15.546 8H14.54l.265-2.91A1 1 0 0 0 13.81 4H9.828zm-2.95-1.707L7.587 3H2.19c-.24 0-.47.042-.684.12L1.5 2.98a1 1 0 0 1 1-.98h3.672a1 1 0 0 1 .707.293z"
        fill-rule="evenodd"
      />
      <path
        d="M13.5 10a.5.5 0 0 1 .5.5v2a.5.5 0 0 1-.5.5h-2a.5.5 0 0 1 0-1H13v-1.5a.5.5 0 0 1 .5-.5z"
        fill-rule="evenodd"
      />
      <path d="M13 12.5a.5.5 0 0 1 .5-.5h2a.5.5 0 0 1 0 1H14v1.5a.5.5 0 0 1-1 0v-2z" fill-rule="evenodd" />
    </svg>
    Add Folder
  </div>
</template>
<style lang="scss">
.btn-add-folder {
  display: flex;
  flex-flow: row nowrap;
  width: 100%;
  border: none;
  align-items: center;
  justify-content: center;
  border-radius: 0 !important;
  svg {
    margin-right: 5px;
  }
}
</style>
<script lang='ts'>
import { Component, Vue } from "vue-property-decorator";
import { mitter } from "@/main";
@Component({})
export default class AddFolderButton extends Vue {
  public get folderSelector(): HTMLElement {
    // @ts-ignore
    return document.getElementById("folderSelector");
  }
  selectorOnChange() {
    console.log("change");
    // @ts-ignore
    mitter.emit("folderSelected", this.folderSelector.files[0].path);
    // @ts-ignore
    this.folderSelector.files.clear();
    // this.folderSelector.removeEventListener("blur", this.selectorOnBlur);
  }
  addFolder() {
    this.folderSelector.click();
  }
}
</script>
