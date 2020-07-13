<template>
  <div>
    <h2>{{title}}</h2>
    <el-table :data="tableData" border stripe>
      <el-table-column prop="Id" label="ID"></el-table-column>
      <el-table-column prop="Age" label="年龄"></el-table-column>
      <el-table-column prop="Name" label="姓名"></el-table-column>
    </el-table>
    <el-button type="primary" @click="loadData"></el-button>
  </div>
</template>

<script>
export default {
  name: "value",
  data() {
    return {
      tableData: [],
      title: "测试Value控制器"
    };
  },
  mounted() {},
  methods: {
    loadData() {
      axios
        .get("http://localhost:9000/api/value/Getall")
        .then(res => {
          this.tableData = res;
        })
        .catch(error => {
          console.log(error);
        });
    }
  }
};
</script>

<style lang="stylus" scoped></style>