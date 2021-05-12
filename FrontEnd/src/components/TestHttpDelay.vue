<template>
  <div>
      <el-button type="primary" size="default" @click="questSlowly">123</el-button>
      
  </div>
</template>
<script>
export default {
  data() {
    return {};
  },
  mounted() {
    this.questSlowly();
    this.questSlowly();
    this.questSlowly();
    this.questSlowly();
    this.questSlowly();
  },
  methods: {
    questFast() {
      this.$axios
        .get("http://localhost:5000/api/goods/test2")
        .then((res) => {
          console.log(res.data.data);
        })
        .catch((error) => {
          console.log(error);
        });
    },
    questSlowly() {
      var that = this;

      // 取消上一次请求
      this.cancelRequest();
      this.$axios
        .get("http://localhost:5000/api/goods/test", null, {
          cancelToken: new that.$axios.CancelToken(function executor(c) {
            that.source = c;
          })
        })
        .then((res) => {
          console.log(res.data.data);
        })
        .catch((error) => {
          if (that.$axios.isCancel(error)) {
            // 返回取消请求信息
            console.log("Rquest canceled", error);
          } else {
            console.log(error);
          }
        });
    },
    cancelRequest() {
      if (typeof this.source === "function") {
        this.source("终止请求");
      }
    },
  },
};
</script>