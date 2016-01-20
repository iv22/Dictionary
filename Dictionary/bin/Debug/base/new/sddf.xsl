<?xml version="1.0" encoding="Windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes" cdata-section-elements="Data"/>

<xsl:template match="Workbook">
      <xsl:element name="Dictionary">
        <xsl:attribute name="id">1</xsl:attribute>
        <xsl:attribute name="id_user">1</xsl:attribute>
        <xsl:attribute name="name">Новый словарь</xsl:attribute>
        <xsl:attribute name="opened">true</xsl:attribute>
        <xsl:apply-templates/>
      </xsl:element>
</xsl:template>

<xsl:template match="Row[Cell/Data]">
		<xsl:element name="Word">
			<xsl:element name="Source">
				<xsl:value-of select="normalize-space(descendant::Cell[1]/Data)"/>
			</xsl:element>
			<xsl:element name="Translate">
				<xsl:value-of select="normalize-space(descendant::Cell[2]/Data)"/>
			</xsl:element>
		</xsl:element>
	</xsl:template>

</xsl:stylesheet>