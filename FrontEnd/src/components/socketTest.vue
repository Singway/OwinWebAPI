<template>
  <div class="socket">
    <!-- <general-dialog @output="output"/> -->
    <el-row :gutter="20">
      <el-input
        v-model="msg"
        style="width: 50%"
        clearable
        @keyup.enter.native="sendMsg"
      ></el-input>
      <el-button type="primary" @click="sendMsg">发送消息</el-button>
    </el-row>
    <br />
    <el-row :gutter="20">
      <el-input
        v-model="receivedMsg"
        disabled
        rows="3"
        type="textarea"
        style="width: 60%"
      ></el-input>
    </el-row>
    <br />
    <el-row :gutter="20">
      <el-button type="primary" size="default" @click="close">关闭</el-button>
      <el-button type="primary" size="default" @click="create"
        >创建连接</el-button
      >
    </el-row>
  </div>
</template>
<script>
import generalDialog from "../customTools/generalDialog";
export default {
  data() {
    return {
      handlerUrl: "ws://localhost:9000/api/socket/get",
      receivedMsg: "", //接收的消息
      msg: "", //发送的消息
    };
  },
  components: {
    generalDialog, //测试子组件调用父组件方法
  },
  mounted() {
    //this.initWebSocket();
    //this.webSocket.onopen();
  },
  methods: {
    initWebSocket() {
      let that = this;
      debugger
      if (!!window.webSocket) {
        return;
      }
      //如果WebSocket对象未初始化，我们将初始化它
      window.webSocket = new WebSocket(this.handlerUrl);
      //打开连接处理程序
      window.webSocket.onopen = function () {
        console.log("WebSocket connected");
      };
      //消息数据处理程序
      window.webSocket.onmessage = function (e) {
        that.receivedMsg += e.data;
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
    output() {
      debugger;
      alert("来了宝贝");
    },
    sendMsg() {
      debugger;
      if (!window.webSocket) {
        alert("找不到socket实例");
        return;
      }
      if (window.webSocket.readyState == window.webSocket.OPEN && !!this.msg) {
        window.webSocket.send(this.msg);
      }
    },
    create() {
      this.initWebSocket();
    },
    close() {},
  },
};
</script>
<style>
.socket {
  margin: 50px;
}
</style>