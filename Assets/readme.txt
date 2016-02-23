■アプリ内のゲームデータについて
○概要
　singletonパターンとstaticインスタンスで引き回す形にします

○参考
　・【Unity】シーン間でスコアを共有　まとめ
　　http://tsubakit1.hateblo.jp/entry/2015/11/07/024350

○適用法
１、プロジェクトにパッケージ(aliceTree.package)をインポート
２、ゲームデータを引き回したいシーンをロード
３、Resources/Prefabs/GameDataをHierarchyに追加
４、ゲームデータを操作したいスクリプトのStart() / Awake() に下記を追加
	GameData gameData = GameData.Instance;

○備考
・GameDataの拡張は自由に行ってかまいませんが、
　拡張内容を共有してください。
　→上書きして悲しいことになるのを防ぐためです。
　→バージョン管理が導入されたら、忘れて構いません