var takevalue;


let ticket = new Vue({
    el: '#ticket',
    data: {
        isBusy: false,
        headVariant: 'dark',
        fixed: true,
        items: [],
        filterOn: ['TicketName'],
        unfields: [
            { key: 'TicketName', label: '折扣券名字', sortable: true, sortDirection: 'desc' },
            { key: 'Discount', label: '折扣', sortable: true, sortDirection: 'desc' },
            //{ key: 'TicketStatus', label: 'TicketStatus', sortable: true, sortDirection: 'desc'},
            { key: 'Ticketdate', label: '使用期限', sortable: true, sortDirection: 'desc' },
            { key: 'PayMethod', label: '可以付款方式', sortable: true, sortDirection: 'desc' },
            { key: 'ProductType', label: '可以購買課程種類', sortable: true, sortDirection: 'desc' },
            { key: 'UseTime', label: '使用次數', sortable: true, sortDirection: 'desc' },
            { key: 'editor', label: '折扣券管理' },
            { key: 'Send', label: '發送狀況', sortable: false, sortDirection: 'desc' }

        ],
        fields: [
            //{ key: 'TicketId', label: 'TicketId', sortable: true, sortDirection: 'desc' },
            { key: 'TicketName', label: '折扣券名字', sortable: true, sortDirection: 'desc' },
            { key: 'Discount', label: '折扣', sortable: true, sortDirection: 'desc' },
            //{ key: 'TicketStatus', label: 'TicketStatus', sortable: true, sortDirection: 'desc'},
            { key: 'Ticketdate', label: '使用期限', sortable: true, sortDirection: 'desc' },
            { key: 'SendDate', label: '發送時間', sortable: true, sortDirection: 'desc' },
            { key: 'PayMethod', label: '可以付款方式', sortable: true, sortDirection: 'desc' },
            { key: 'ProductType', label: '可以購買課程種類', sortable: true, sortDirection: 'desc' },
            { key: 'UseTime', label: '使用次數', sortable: true, sortDirection: 'desc' },

            { key: 'Send', label: '發送狀況', sortable: false, sortDirection: 'desc' }

        ],
        TicketForm: {
            ticketID: "Ticket" + Math.floor(Math.random() * 1000),
            ticketName: "",
            ticketStatus: "可使用",
            ticketDiscount: "",
            ticketDate: new Date(),
            PayMethod: "",
            ProductType: "",
            UseTime: "",
            Send: false
        },
        //sendTickets: [],
        //unsendTickets: [],
        UpdateForm: {},
        totalRows: 1,
        currentPage: 1,
        untotalRows: 1,
        uncurrentPage: 1,
        unperPage:5,
        perPage: 5,
        pageOptions: [5, 10, 15, { value: 100, text: "Show a lot" }],
        unpageOptions: [5, 10, 15, { value: 100, text: "Show a lot" }],
        sortBy: '',
        sortDesc: false,
        sortDirection: 'asc',
        Filter: null,
        unFilter: null,
        filterOn: [],
        infoModal: {
            id: 'info-modal',
            title: '',
            content: '',
            ticketID: null
        },
        infoModalEdit: {
            id: 'info-modal-edit',
            title: '',
            content: ''
        }
    },
    watch: {
        //items: function () {
        //    alert("測試")
        //}
    },
    computed: {
        sortOptions() {
            // Create an options list from our fields
            return this.fields
                .filter(f => f.sortable)
                .map(f => {
                    return { text: f.label, value: f.key }
                })
        },
        unsendTickets() {
            return this.items.filter(x => x.Send == 'false');
        },
        sendTickets() {
            return this.items.filter(x => x.Send == 'true');
        }
    },
    mounted() {
        this.getData();

    },
    methods: {
        info(item, index, button) {
            this.infoModal.title = `${item.TicketId}號-折扣券`
            this.infoModal.content = `確定發送${item.TicketId}號折扣券?`
            this.$root.$emit('bv::show::modal', this.infoModal.id, button)
            this.infoModal.ticketId = item.TicketId
        },
        infoEdit(item, index, button) {
            this.infoModalEdit.title = `編輯 ${item.TicketId}號-積分券`
            this.infoModalEdit.content = `確定編輯${item.TicketId}號積分券?`
            this.$root.$emit('bv::show::modal', this.infoModalEdit.id, button)

            this.UpdateForm = {
                ticketID: item.TicketId,
                ticketDiscount: item.Discount,
                ticketPayMethod: item.PayMethod,
                ticketProductType: item.ProductType,
                ticketUseTime: item.UseTime,
                ticketDate: item.Ticketdate.replace('/', '-').replace('/', '-')
            }

        },
        resetInfoModal() {
            this.infoModal.title = ''
            this.infoModal.content = ''
        },
        onFiltered(filteredItems) {
            // Trigger pagination to update the number of buttons/pages due to filtering
            this.totalRows = filteredItems.length
            this.currentPage = 1
        },
        sendValue() {
            if (takevalue != null) {
                $.ajax({
                    url: 'https://localhost:44363/orders/SendInvite?ticketid=' + takevalue,
                    type: "POST",
                    success: function () {

                    }

                })
                alert("折價卷已發送");
            }
            else {
                alert("尚未選取折扣卷")
            }


        },
        getData() {
            var that = this
            $.ajax({
                url: 'https://localhost:44363/orders/Ticketdata',
                type: "GET",
                //async: false,
                success: function (returnData) {
                    that.items = JSON.parse(returnData)
                    if (that.sendTickets.length != 0) {
                        that.totalRows = that.sendTickets.length

                    }

                    if (that.unsendTickets.length != 0) {
                        that.untotalRows = that.unsendTickets.length
                    }

                    //console.warn(that.unsendTickets)
                }

            })
        },
        postTicket() {

            console.log(this.TicketForm)
            axios.post('https://localhost:44363/Orders/Create', {
                TicketId: this.TicketForm.ticketID,
                TicketName: this.TicketForm.ticketName,
                TicketStatus: this.TicketForm.ticketStatus,
                Discount: parseFloat(this.TicketForm.ticketDiscount),
                Ticketdate: new Date(this.TicketForm.ticketDate),
                PayMethod: this.TicketForm.PayMethod,
                ProductType: this.TicketForm.ProductType,
                UseTime: this.TicketForm.UseTime,
                Send: "false"
            }).then((res) => {
                this.getData()
            }).finally(() => {
                //app.sort(app.items)
            })


        },
        sendPoint(id) {
            axios.patch(`https://localhost:44363/orders/SendInvite?ticketid=${id}`)
                .then((res) => {
                    this.getData();

                })
        },
        upDateTicket() {
            var result = {
                TicketId: this.UpdateForm.ticketID,              
                Discount: parseFloat(this.UpdateForm.ticketDiscount),
                Ticketdate: new Date(this.UpdateForm.ticketDate),
                PayMethod: this.UpdateForm.ticketPayMethod,
                ProductType: this.UpdateForm.ticketProductType,
                UseTime: this.UpdateForm.ticketUseTime,
            }
            axios.put('https://localhost:44363/orders/Update', result)
                .then((res) => {
                    this.getData();

                })
        },

    }
});
