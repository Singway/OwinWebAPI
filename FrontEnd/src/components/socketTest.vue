<template>
  <div>
    <general-dialog @output="output"/>
  </div>
</template>
<script>
import generalDialog from '../customTools/generalDialog'
export default {
  data() {
    return {
      //webSocket: {},
      webSocket1: { binaryType: "" },
      handlerUrl: "ws://localhost:9000/api/socket/get",
    };
  },
  components:{
    generalDialog,//测试子组件调用父组件方法
  },
  mounted() {
    //this.initWebSocket();
    //this.loadData();
    //this.webSocket.onopen();
  },
  methods: {
    initWebSocket() {
      //如果WebSocket对象未初始化，我们将初始化它
      window.webSocket = new WebSocket(this.handlerUrl);
      //打开连接处理程序
      window.webSocket.onopen = function () {
        console.log("WebSocket connected");
      };
      //消息数据处理程序
      window.webSocket.onmessage = function (e) {
        console.log(e.data);
      };

      //关闭事件处理程序
      window.webSocket.onclose = function () {
        console.log("WebSocket closed.");
      };

      //错误事件处理程序
      window.webSocket.onerror = function (e) {
        console.log(e.message);
      };
    },
    loadData() {
      this.$axios
        .get("http://localhost:9000/api/socket/get")
        .then((res) => {
          this.tableData = res.data;
        })
        .catch((error) => {
          console.log(error);
        });
    },
    output(){
      debugger
      alert("来了宝贝");
    }
  },
};
</script>