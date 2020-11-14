<template>
    <div>
        <el-button type="primary" @click="test">调用父类方法</el-button>
    </div>
</template>
<script>
export default {
    data() {
        return {
            
        }
    },
    mounted() {
        
    },
    methods: {
        test(){
            debugger
            this.$emit("output");
        }
    },
}
</script>