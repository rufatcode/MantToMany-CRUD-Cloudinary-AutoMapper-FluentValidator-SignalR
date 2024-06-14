"use strict";






$(document).ready(function () {
    
    

    var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
    console.log(connection);
    connection.start();


    let btn = $(".sendIcon");
    let messageInput = $(".messageInput");
    btn.click(function () {
        let ul = $(".usermessagesList");
        connection.invoke("SendMessageAsync", ul.attr("data-id"), messageInput.attr("data-id"), messageInput.val());
        
        messageInput.val("");

    })

    connection.on("RecieveMessage", function (fromId, toId, message) {
        console.log(fromId)
        console.log(toId)
        console.log(message)
        let ul = $(".usermessagesList")
        if (ul.attr("data-id") == toId) {
            let li = `
    <li class="clearfix">
                                    <div class="message-data">
                                        <span class="message-data-time">10:15 AM, Today</span>
                                    </div>
                                    <div class="message my-message">${message}</div>
                                </li>
    `
            ul.append(li);
        }
    })
   





    messageInput.keyup(function () {
        connection.invoke("SendTyping", messageInput.attr("data-id"))
    })
    connection.on("GetTyping", function (id) {
        $(`#${id + "Typing"}`).removeClass("d-none");
        setTimeout(function () {
            $(`#${id + "Typing"}`).addClass("d-none");
        },2000)
    })



    connection.on("OnConnected", function (id) {
        $(`#${id + "status"}>i`).removeClass("offline")
         $(`#${id + "status"}>i`).addClass("online")
        $(`#${id + "status"}>span`).html("online")
        $(`#${id + "time"}`).html("online")
    })

    connection.on("OnDisConnected", function (id,time) {
        $(`#${id + "status"}>i`).addClass("offline")
        $(`#${id + "status"}>i`).removeClass("online")
        $(`#${id + "status"}>span`).html("offline")
        $(`#${id + "time"}`).html(time)
    })

    $(".userslist>li").click(function () {
        let dataId = $(this).attr("data-id");
        $(".userslist>li").removeClass("active")
        $(".usermessagesList").attr("data-id",+ dataId)
        $(this).addClass("active");
        axios.get(`/Chat/Get/${dataId}`).then(res => {
            console.log(res.data)
            $(".userNameHeadling").html(res.data.fullName)
            $(".lastDisconenctedTime").attr("id", res.data.id +"time");
            if (res.data.lastDisconnectedTime != null) {
                $(".lastDisconenctedTime").html(res.data.lastDisconnectedTime)
            }
            else {
                $(".lastDisconenctedTime").html("online")
            }
            
        })

        
    })


   
});