<template>
  <div id="app">
    <el-form :model="form" ref="form" label-width="80px">
      <el-row>
        <el-col :span="8">
          <el-form-item label>
            <el-input v-model="form.msg" placeholder="请输入消息"></el-input>
          </el-form-item>
        </el-col>
        <el-col :span="4">
          <el-form-item>
            <el-button type="primary" @click="onSubmit">发送</el-button>
          </el-form-item>
        </el-col>
      </el-row>
    </el-form>
    <div>{{messages}}</div>
    <router-view></router-view>
  </div>
</template>

<script>
import HelloWorld from "./components/HelloWorld.vue";
import Value from "./components/Value.vue";

export default {
  name: "App",
  components: {
    HelloWorld,
    Value
  },
  data() {
    return {
      form: {
        msg: ""
      },
      messages: ""
    };
  }
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
