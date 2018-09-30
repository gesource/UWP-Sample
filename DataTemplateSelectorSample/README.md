# DataTemplateSelectorでDataTemplateを切り替える

![](DataTemplateSelectorSample.png)

ListViewのDataTemplateをデータの内容によって切り替える方法です。

NameプロパティとAgeプロパティを持つPersonクラスがあります。

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

XAMLでは、Ageが20未満のときと、Ageが20以上のときのDataTemplateを用意します。

    <Page.Resources>
        <ResourceDictionary>
            <!--  Ageが20未満のときのテンプレート  -->
            <DataTemplate x:Key="under20Template">
                <TextBlock>
                    <Run Text="{Binding Name}" />
                    (<Run Text="{Binding Age}" />
                    )</TextBlock>
            </DataTemplate>
            <!--  Ageが20以上のときのテンプレート  -->
            <DataTemplate x:Key="over20Template">
                <TextBlock>
                    <Run FontWeight="ExtraBold" Text="{Binding Name}" />
                    (<Run FontWeight="ExtraBold" Text="{Binding Age}" />
                    )</TextBlock>
            </DataTemplate>
        </ResourceDictionary>
    </Page.Resources>

ListViewのItemTemplateSelectorでは、DataTemplateを切り替えるPersonTemplateSelectorを設定します。

    <ListView ItemsSource="{x:Bind Items}">
        <!--  使用するDataTemplateを選択するデータテンプレートセレクターの設定  -->
        <ListView.ItemTemplateSelector>
            <local:PersonTemplateSelector
                Over20Template="{StaticResource over20Template}"
                Under20Template="{StaticResource under20Template}" />
        </ListView.ItemTemplateSelector>
    </ListView>

PersonTemplateSelectorは、SelectTemplateCore()メソッドでデータの内容によって適切なDataTemplateを返します。

    public class PersonTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Ageが20未満のときのテンプレート
        /// </summary>
        public DataTemplate Under20Template { get; set; }
        /// <summary>
        /// Ageが20以上のときのテンプレート
        /// </summary>
        public DataTemplate Over20Template { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            var person = (Person)item;
            if (person.Age < 20)
                return Under20Template;
            else
                return Over20Template;
        }
    }
